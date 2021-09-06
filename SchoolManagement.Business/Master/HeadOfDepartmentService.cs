using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Util;
using SchoolManagement.Model.Master;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Model.Common.Enums;

namespace SchoolManagement.Business.Master
{
    public class HeadOfDepartmentService : IHeadOfDepartmentService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public HeadOfDepartmentService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config , ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<HeadOfDepartmentViewModel> GetAllHeadOfDepartment()
        {
            var response = new List<HeadOfDepartmentViewModel>();

            var query = schoolDb.HeadOfDepartments.Where(hod => hod.IsActive == true);

            var HeadOfDepartmentList = query.ToList();

            foreach (var HeadOfDepartment in HeadOfDepartmentList)
            {
                var viewModel = new HeadOfDepartmentViewModel
                {
                    Id = HeadOfDepartment.Id,
                    SubjectId = HeadOfDepartment.SubjectId,
                    AcademicLevelId = HeadOfDepartment.AcademicLevelId,
                    AcademicYearId = HeadOfDepartment.AcademicYearId,
                    TeacherId = HeadOfDepartment.TeacherId,
                    IsActive = HeadOfDepartment.IsActive,
                    CreateOn = HeadOfDepartment.CreateOn,
                    CreatedById = HeadOfDepartment.CreatedById,
                    UpdateOn = HeadOfDepartment.UpdateOn,
                    UpdatedById = HeadOfDepartment.UpdatedById,
                };

                response.Add(viewModel);

            }

            return response;
        }

        public async Task<ResponseViewModel> SaveHeadOfDepartment(HeadOfDepartmentViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = currentUserService.GetUserByUsername(userName);

                var HeadOfDepartments = schoolDb.HeadOfDepartments.FirstOrDefault(hod => hod.Id == vm.Id);

                if (HeadOfDepartments == null)
                {
                    HeadOfDepartments = new HeadOfDepartment()
                    {
                        Id = vm.Id,
                        SubjectId = vm.SubjectId,
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        TeacherId = vm.TeacherId,
                        IsActive = true,
                        CreateOn = vm.CreateOn,
                        CreatedById = currentuser.Id,
                        UpdateOn = DateTime.UtcNow,
                        UpdatedById = currentuser.Id,
                    };

                    schoolDb.HeadOfDepartments.Add(HeadOfDepartments);

                    response.IsSuccess = true;
                    response.Message = "Head Of Department successfully created";
                }
                else
                {
                    HeadOfDepartments.SubjectId = vm.SubjectId;
                    HeadOfDepartments.AcademicYearId = vm.AcademicYearId;
                    HeadOfDepartments.AcademicLevelId = vm.AcademicLevelId;
                    HeadOfDepartments.IsActive = true;
                    HeadOfDepartments.UpdatedById = currentuser.Id;
                    HeadOfDepartments.UpdateOn = DateTime.UtcNow;

                    schoolDb.HeadOfDepartments.Update(HeadOfDepartments);

                    response.IsSuccess = true;
                    response.Message = "Head Of Department successfully updated";
                }

                await schoolDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while saving the Head Of Department.";
            }
            return response;
        }

        public async Task<ResponseViewModel> DeleteHeadOfDepartment(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var HeadOfDepartment = schoolDb.HeadOfDepartments.FirstOrDefault(hod => hod.Id == id);

                HeadOfDepartment.IsActive = false;
                schoolDb.HeadOfDepartments.Update(HeadOfDepartment);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Head Of Department is successfully deleted";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }

            return response;
        }

        
        public List<DropDownViewModel> GetAllAcademicYears()
        {
            var academicYears = schoolDb.AcademicYears
                .Where(x => x.IsActive == true)
                .Select(ay => new DropDownViewModel() { Id = ay.Id })
                .Distinct().ToList();

            return academicYears;
        }

        public List<DropDownViewModel> GetAllAcademicLevels()
        {
            var academicLevels = schoolDb.AcademicLevels
                .Where(x => x.IsActive == true)
                .Select(al => new DropDownViewModel() { Id = al.Id, Name = string.Format("{0}", al.Name) })
                .Distinct().ToList();

            return academicLevels;
        }

        public List<DropDownViewModel> GetAllTeachers()
        {
            var teachers = schoolDb.UserRoles
                .Where(x => x.RoleId == (int)RoleType.Teacher)
                .Select(t => new DropDownViewModel() { Id = t.User.Id, Name = string.Format("{0}", t.User.FullName) })
                .Distinct().ToList();

            return teachers;
        }

        public List<DropDownViewModel> GetAllSubjects()
        {
            var subjects = schoolDb.Subjects
                .Where(x => x.SubjectCode != null)
                .Select(s => new DropDownViewModel() { Id = s.Id, Name = string.Format("{0}", s.Name) })
                .Distinct().ToList();

            return subjects;
        }
    }
}
