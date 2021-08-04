using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Master
{
    public class SubjectTeacherService: ISubjectTeacherService
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

        public async Task<ResponseViewModel> DeleteSubjectTeacher(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var subjectTecher = schoolDb.SubjectTeachers.FirstOrDefault(x => x.Id == id);

                subjectTecher.IsActive = false;

                schoolDb.SubjectTeachers.Update(subjectTecher);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Subject Techer Delete Successfull";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }

        public List<SubjectTeacherViewModel> GetAllSubjectTeachers()
        {
            var response = new List<SubjectTeacherViewModel>();

            var query = schoolDb.SubjectTeachers.Where(st => st.IsActive == true);

            var SubjectTeacherList = query.ToList();

            foreach (var subjectTeacher in SubjectTeacherList)
            {
                var vm = new SubjectTeacherViewModel()
                {
                    Id = subjectTeacher.Id,
                    AcademicLevelId = subjectTeacher.AcademicLevelId,
                    AcademicYearId = subjectTeacher.AcademicYearId,
                    SubjectId = subjectTeacher.SubjectId,
                    TeacherId = subjectTeacher.TeacherId,
                    StartDate = subjectTeacher.StartDate,
                    EndDate = subjectTeacher.EndDate,
                    IsActive = subjectTeacher.IsActive,
                };
                response.Add(vm);
            }
            return response;
        }

        public async Task<ResponseViewModel> SaveSubjectTeacher(SubjectTeacherViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var subjectTeachers = schoolDb.SubjectTeachers.FirstOrDefault(x => x.Id == vm.Id);

                if(subjectTeachers == null) 
                {
                    subjectTeachers = new SubjectTeacher()
                    {
                        Id = vm.Id,
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        SubjectId = vm.SubjectId,
                        TeacherId = vm.TeacherId,
                        StartDate = vm.StartDate,
                        EndDate = vm.EndDate,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id,
                    };

                    schoolDb.SubjectTeachers.Add(subjectTeachers);

                    response.IsSuccess = true;
                    response.Message = "Subject Teacher Add Successfull.";
                }
                else
                {
                    subjectTeachers.AcademicLevelId = vm.AcademicLevelId;
                    subjectTeachers.AcademicYearId = vm.AcademicYearId;
                    subjectTeachers.SubjectId = vm.SubjectId;
                    subjectTeachers.TeacherId = vm.TeacherId;
                    subjectTeachers.StartDate = vm.StartDate;
                    subjectTeachers.EndDate = vm.EndDate;
                    subjectTeachers.IsActive = true;
                    subjectTeachers.UpdatedOn = DateTime.UtcNow;
                    subjectTeachers.UpdatedById = loggedInUser.Id;

                    schoolDb.SubjectTeachers.Update(subjectTeachers);

                    response.IsSuccess = true;
                    response.Message = "Subject Teacher Update Successfull.";
                }
                await schoolDb.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }
    }
}








