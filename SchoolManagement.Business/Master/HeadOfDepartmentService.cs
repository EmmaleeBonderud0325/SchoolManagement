using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Util;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Model.Common.Enums;
using SchoolManagement.Util.Constants.ServiceClassConstants;

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
                    SubjectName = HeadOfDepartment.Subject.Name,
                    AcademicLevelId = HeadOfDepartment.AcademicLevelId,
                    AcademicLevelName = HeadOfDepartment.AcademicLevel.Name,
                    AcademicYearId = HeadOfDepartment.AcademicYearId,
                    TeacherId = HeadOfDepartment.TeacherId,
                    TeacherName = GetTeacher(HeadOfDepartment.TeacherId),
                    IsActive = HeadOfDepartment.IsActive,
                    CreateOn = HeadOfDepartment.CreateOn,
                    CreatedById = HeadOfDepartment.CreatedById,
                    CreatedByName = HeadOfDepartment.CreatedBy.FullName,
                    UpdateOn = HeadOfDepartment.UpdateOn,
                    UpdatedById = HeadOfDepartment.UpdatedById,
                    UpdatedByName = HeadOfDepartment.UpdatedBy.FullName,
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

                var HeadOfDepartment = schoolDb.HeadOfDepartments.FirstOrDefault(hod => hod.Id == vm.Id);

                if (HeadOfDepartment == null)
                {
                    HeadOfDepartment = new HeadOfDepartment()
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

                    schoolDb.HeadOfDepartments.Add(HeadOfDepartment);

                    response.IsSuccess = true;
                    response.Message = "Head Of Department successfully created";
                }
                else
                {
                    HeadOfDepartment.SubjectId = vm.SubjectId;
                    HeadOfDepartment.AcademicYearId = vm.AcademicYearId;
                    HeadOfDepartment.AcademicLevelId = vm.AcademicLevelId;
                    HeadOfDepartment.TeacherId = vm.TeacherId;
                    HeadOfDepartment.IsActive = true;
                    HeadOfDepartment.UpdatedById = currentuser.Id;
                    HeadOfDepartment.UpdateOn = DateTime.UtcNow;

                    schoolDb.HeadOfDepartments.Update(HeadOfDepartment);

                    response.IsSuccess = true;
                    response.Message = "Head Of Department successfully updated";
                }

                await schoolDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
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
            /* var teachers = schoolDb.UserRoles
                 .Where(x => x.RoleId == (int)RoleType.Teacher)
                 .Select(t => new DropDownViewModel() { Id = t.User.Id, Name = string.Format("{0}", t.User.FullName) })
                 .Distinct().ToList();

             return teachers;*/


            var teachers = schoolDb.SubjectTeachers
                .Where(x => x.IsActive == true)
                .Select(t => new DropDownViewModel() { Id = t.Id, Name = string.Format("{0}", t.Teacher.FullName) })
                .Distinct().ToList();

            return teachers;
        }

        public List<DropDownViewModel> GetAllSubjects ()
        {
            var subjects = schoolDb.Subjects
                .Where(x => x.IsActive == true )
                .Select(s => new DropDownViewModel() { Id = s.Id, Name = string.Format("{0}", s.Name) })
                .Distinct().ToList();

            return subjects;
        }

        private string GetTeacher(int TeacherId)
        {
            var quary = schoolDb.SubjectTeachers.FirstOrDefault(T => T.Id == TeacherId);

            if (quary == null)
            {
                return HeadOfDepartmentServiceConstants.HEAD_OF_DEPARTMENT_TEACHER_NOT_fOUND_MESSAGE;
            }
            else
            {
                return quary.Teacher.FullName;
            }
        }
    }
}
