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
    public class ClassSubjectTeacherService : IClassSubjectTeacherService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public ClassSubjectTeacherService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public async Task<ResponseViewModel> DeleteClassSubjectTeacher(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var classSubjectTeacher = schoolDb.ClassSubjectTeachers.FirstOrDefault(x => x.Id == id);

                classSubjectTeacher.IsActive = false;

                schoolDb.ClassSubjectTeachers.Update(classSubjectTeacher);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Class Subject Teacher Delete Successfull";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }

        public List<ClassSubjectTeacherViewModel> GetAllClassSubjectTeachers()
        {
            var response = new List<ClassSubjectTeacherViewModel>();

            var query = schoolDb.ClassSubjectTeachers.Where(sct => sct.IsActive == true);

            var SubjectClassTeacherList = query.ToList();

            foreach(var subjectClassTeacher in SubjectClassTeacherList)
            {
                var vm = new ClassSubjectTeacherViewModel() 
                {
                     Id = subjectClassTeacher.Id,
                     ClassNameId = subjectClassTeacher.ClassNameId,
                     AcademicLevelId = subjectClassTeacher.AcademicLevelId,
                     AcademicYearId = subjectClassTeacher.AcademicYearId,
                     SubjectId = subjectClassTeacher.SubjectId,
                     SubjectTeacherId = subjectClassTeacher.SubjectTeacherId,
                     StartDate = subjectClassTeacher.StartDate,
                     EndDate = subjectClassTeacher.EndDate,
                     IsActive = subjectClassTeacher.IsActive,
                };
                response.Add(vm);
            }
            return response;
        }

        public async Task<ResponseViewModel> SaveClassSubjectTeacher(ClassSubjectTeacherViewModel vm, string userName)
        {
            var response = new ResponseViewModel();


            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var classSubjectTeacher = schoolDb.ClassSubjectTeachers.FirstOrDefault(x => x.Id == vm.Id);

                if (classSubjectTeacher == null)
                {
                    classSubjectTeacher = new ClassSubjectTeacher()
                    {
                        Id = vm.Id,
                        ClassNameId = vm.ClassNameId,
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        SubjectId = vm.SubjectId,
                        SubjectTeacherId = vm.SubjectTeacherId,
                        StartDate = vm.StartDate,
                        EndDate = vm.EndDate,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id,
                    };

                    schoolDb.ClassSubjectTeachers.Add(classSubjectTeacher);

                    response.IsSuccess = true;
                    response.Message = "Class Subject Teacher Add Successfull.";
                }
                else 
                {
                    classSubjectTeacher.ClassNameId = vm.ClassNameId;
                    classSubjectTeacher.AcademicLevelId = vm.AcademicLevelId;
                    classSubjectTeacher.AcademicYearId = vm.AcademicYearId;
                    classSubjectTeacher.SubjectId = vm.SubjectId;
                    classSubjectTeacher.SubjectTeacherId = vm.SubjectTeacherId;
                    classSubjectTeacher.StartDate = vm.StartDate;
                    classSubjectTeacher.EndDate = vm.EndDate;
                    classSubjectTeacher.IsActive = true;

                    schoolDb.ClassSubjectTeachers.Update(classSubjectTeacher);

                    response.IsSuccess = true;
                    response.Message = "Class Subject Teacher Update Successfull.";
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
    }
}





