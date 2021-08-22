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

namespace SchoolManagement.Business.Master
{
    public class ClassTeacherService: IClassTeacherService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public ClassTeacherService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<ClassTeacherViewModel> GetClassTeachers()
        {
            var response = new List<ClassTeacherViewModel>();

            var query = schoolDb.ClassTeachers.Where(u => u.IsActive == true);

            var ClassTeacherList = query.ToList();

            foreach (var classteacher in ClassTeacherList)
            {
                var vm = new ClassTeacherViewModel
                {
                    ClassNameId = classteacher.ClassNameId,
                    AcademicLevelId = classteacher.AcademicLevelId,
                    AcademicYearId = classteacher.AcademicYearId,
                    TeacherId = classteacher.TeacherId,
                    IsPrimary = classteacher.IsPrimary,
                    IsActive = classteacher.IsActive,
                    CreatedOn = classteacher.CreatedOn,
                    CreatedById = classteacher.CreatedById,
                    UpdatedOn = classteacher.UpdatedOn,
                    UpdatedById = classteacher.UpdatedById,
                };

                response.Add(vm);
            }

            return response;
        }

        public async Task <ResponseViewModel> SavaClassTeacher(ClassTeacherViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

                var classTeacher = schoolDb.ClassTeachers.FirstOrDefault(x => x.ClassNameId == vm.ClassNameId);

                if (classTeacher == null)
                {
                    classTeacher = new ClassTeacher()
                    {
                        ClassNameId = vm.ClassNameId,
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        TeacherId = vm.TeacherId,
                        IsPrimary = true,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = vm.CreatedById,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = vm.UpdatedById
                    };

                    schoolDb.ClassTeachers.Add(classTeacher);

                    response.IsSuccess = true;
                    response.Message = "Class Teacher Added Successfull.";
                }
                else
                {
                    classTeacher.IsPrimary = true;
                    classTeacher.IsActive = true;
                    classTeacher.UpdatedOn = DateTime.UtcNow;
                    classTeacher.UpdatedById = vm.UpdatedById;
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

        public async Task<ResponseViewModel> DeleteClassTeacher(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var classTeacher = schoolDb.ClassTeachers.FirstOrDefault(x => x.ClassNameId == id);

                classTeacher.IsActive = false;

                schoolDb.ClassTeachers.Update(classTeacher);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Class Teacher Deleted Successfull.";
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
