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
using SchoolManagement.Util.Constants.ServiceClassConstants;

namespace SchoolManagement.Business.Master
{
    public class ClassService: IClassService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public ClassService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<ClassViewModel> GetClasses()
        {
            var response = new List<ClassViewModel>();

            var query = schoolDb.Classes.Where(predicate: cn => cn.ClassNameId != 0);

            var ClassList = query.ToList();

            foreach (var item in ClassList)
            {
                var vm = new ClassViewModel
                {
                    ClassNameId = item.ClassNameId,
                    ClassClassName = item.ClassName.Name,
                    AcademicLevelId = item.AcademicLevelId,
                    AcademicLevelName = item.AcademicLevel.Name,
                    AcademicYearId = item.AcademicYearId,
                    Name = item.Name,
                    ClassCategory = item.ClassCategory,
                    ClassCategoryName = item.ClassCategory.ToString(),
                    LanguageStream = item.LanguageStream,
                    LanguageStreamName = item.LanguageStream.ToString(),
                    CreatedOn = item.CreatedOn,
                    CreatedById = item.CreatedById,
                    CreatedByName = item.CreatedBy.FullName,
                    UpdatedOn = item.UpdatedOn,
                    UpdatedById = item.UpdatedById,
                    UpdatedByName = item.UpdatedBy.FullName,
                };

                response.Add(vm);
            }

            return response;
        }

        public async Task <ResponseViewModel> SavaClass(ClassViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = currentUserService.GetUserByUsername(userName);

                var classes = schoolDb.Classes.FirstOrDefault(x => x.ClassNameId == vm.ClassNameId);

                if (classes == null)
                {
                    classes = new Class()
                    {
                        ClassNameId = vm.ClassNameId,
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        Name = vm.Name,
                        ClassCategory = vm.ClassCategory,
                        LanguageStream = vm.LanguageStream,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = currentuser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = currentuser.Id,
                    };

                    schoolDb.Classes.Add(classes);

                    response.IsSuccess = true;
                    response.Message = ClassServiceConstants.NEW_CLASS_SAVE_SUCCESS_MESSAGE;
                }
                else
                {
                    classes.Name = vm.Name;
                    classes.ClassCategory = vm.ClassCategory;
                    classes.LanguageStream = vm.LanguageStream;
                    classes.UpdatedOn = DateTime.UtcNow;
                    classes.UpdatedById = currentuser.Id;

                    schoolDb.Classes.Update(classes);

                    response.IsSuccess = true;
                    response.Message = ClassServiceConstants.EXISTING_CLASS_SAVE_SUCCESS_MESSAGE;
                }

                await schoolDb.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ClassServiceConstants.CLASS_SAVE_EXCEPTION_MESSAGE;
            }

            return response;
        }

        public async Task<ResponseViewModel> DeleteClass(int classNameid)
        {
            var response = new ResponseViewModel();

            try
            {
                var classes = schoolDb.Classes.FirstOrDefault(x => x.ClassNameId == classNameid);

                schoolDb.Classes.Update(classes);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = ClassServiceConstants.CLASS_DELETE_SUCCESS_MESSAGE;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ClassServiceConstants.CLASS_DELETE_EXCEPTION_MESSAGE;
            }

            return response;
        }

       

       

       
    }
}