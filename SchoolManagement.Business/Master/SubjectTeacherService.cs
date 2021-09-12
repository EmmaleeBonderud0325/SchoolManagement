using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Master
{
  public class SubjectTeacherService : ISubjectTeacherService
  {
    private readonly MasterDbContext masterDb;
    private readonly SchoolManagementContext schoolDb;
    private readonly IConfiguration config;
    private readonly ICurrentUserService currentUserService;

    public SubjectTeacherService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
    {
      this.masterDb = masterDb;
      this.schoolDb = schoolDb;
      this.config = config;
      this.currentUserService = currentUserService;
    }

    public SubjectTeacherMasterDataViewModel GetSubjectTeacherMasterData()
    {
      var response = new SubjectTeacherMasterDataViewModel();

      response.CurrentAcademicYear = schoolDb.AcademicYears.FirstOrDefault(x => x.IsActive).Id;
      response.AcademicYears = schoolDb.AcademicYears.OrderBy(x => x.Id).Select(a => new DropDownViewModel() { Id = a.Id, Name = a.Id.ToString() }).ToList();
      response.AcademicLevels = schoolDb.AcademicLevels.OrderBy(x => x.Name).Select(a => new DropDownViewModel() { Id = a.Id, Name = a.Name }).ToList();


      return response;
    }

    public List<DropDownViewModel> GetSubjectsForSelectedAcademicLevel(int academicLevelId)
    {
      var response = new List<DropDownViewModel>();
      //response.Add(new DropDownViewModel() { Id = 0, Name = "---Select---" });
      response.AddRange(schoolDb.SubjectAcademicLevels.Where(x => x.AcademicLevelId == academicLevelId).Select(s => new DropDownViewModel() { Id = s.SubjectId, Name = s.Subject.Name }).ToList());

      return response;
    }

    public List<SubjectTeachersViewModel> GetAllSubjectTeachers(SubjectTeacherFilter filter)
    {
      var vms = new List<SubjectTeachersViewModel>();


      var academicLevelSubjects = schoolDb.SubjectAcademicLevels
        .Where(x => x.AcademicLevelId == filter.SelectedAcademicLevelId).OrderBy(s=>s.Subject.Name).ToList();


      if(!string.IsNullOrEmpty(filter.SearchText))
      {
        academicLevelSubjects = schoolDb.SubjectAcademicLevels
        .Where(x => x. Subject.Name.Contains(filter.SearchText)).OrderBy(s => s.Subject.Name).ToList();
      }

      var allTeachers = schoolDb.Roles.Where(x => x.Id == 6)
        .SelectMany(r => r.UserRoles)
        .Select(x => new DropDownViewModel() { Id = x.User.Id, Name = x.User.FullName })
        .ToList();
           

      foreach (var item in academicLevelSubjects)
      {
        var vm = new SubjectTeachersViewModel();
        vm.Subject = item.Subject.Name;
        vm.SubjectId = item.Subject.Id;
        vm.AcademicLevelId = item.AcademicLevelId;
        vm.AcademicYearId = filter.SelectedAcademicYearId;

        var assignedSubjectTeachers = item.Subject.SubjectTeachers.Where(x => x.AcademicYearId == filter.SelectedAcademicYearId).ToList();

        vm.AssignedTeacherIds = assignedSubjectTeachers.Select(x => x.TeacherId).ToList();
        vm.AssignedSubjectTeachersName = string.Join(",", assignedSubjectTeachers.Select(x => x.Teacher.FullName).ToList());
        vm.AssignedTeachersCount = assignedSubjectTeachers.Count;
        vm.AllTeachers = allTeachers;

        vms.Add(vm);
      }

      return vms;
    }

    public async Task<ResponseViewModel> SaveSubjectTeacher(SubjectTeachersViewModel vm, string userName)
    {
      var response = new ResponseViewModel();

      try
      {
        var loggedInUser = currentUserService.GetUserByUsername(userName);

        var alreadySavedTeachers = schoolDb.SubjectTeachers.Where(x => x.SubjectId == vm.SubjectId && x.AcademicYearId == vm.AcademicYearId && x.AcademicLevelId == vm.AcademicLevelId && x.EndDate.HasValue==false).ToList();

        var newlyAddedTecahersId = (from t in vm.AssignedTeacherIds where !alreadySavedTeachers.Any(s => s.TeacherId == t) select t);

        foreach (var teacherId in newlyAddedTecahersId)
        {
          var subjectTeacher = new SubjectTeacher()
          {
            AcademicLevelId = vm.AcademicLevelId,
            AcademicYearId=vm.AcademicYearId,
            SubjectId=vm.SubjectId,
            TeacherId=teacherId,
            StartDate = DateTime.UtcNow,
            IsActive=true,
            CreatedOn=DateTime.UtcNow,
            CreatedById=loggedInUser.Id,
            UpdatedOn= DateTime.UtcNow,
            UpdatedById=loggedInUser.Id
          };

          schoolDb.SubjectTeachers.Add(subjectTeacher);
        }

        var deletedTeachers = (from d in alreadySavedTeachers where vm.AssignedTeacherIds.Any(x => x == d.TeacherId) select d).ToList();
        foreach (var item in deletedTeachers)
        {
          item.EndDate = DateTime.UtcNow;
          item.IsActive = false;
          item.UpdatedById = loggedInUser.Id;
          item.UpdatedOn = DateTime.UtcNow;

          schoolDb.SubjectTeachers.Update(item);
        }

        await schoolDb.SaveChangesAsync();

        response.IsSuccess = true;
        response.Message = "Subject Teachers details saved succesfully.";
      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Message = "Error has been occured while saving the subject teachers details. Please try again.";
      }
      return response;
    }
  }
}








