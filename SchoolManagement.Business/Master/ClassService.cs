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

            var query = schoolDb.Classes.Where(predicate: cn => cn.ClassNameId != null);

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

        public List<DropDownViewModel> GetAllClassNames()
        {
            var classNames = schoolDb.ClassNames
                .Where(x => x.IsActive == true)
                .Select(cn => new DropDownViewModel() { Id = cn.Id, Name = string.Format("{0}", cn.Name) })
                .Distinct().ToList();

            return classNames;
        }

        public List<DropDownViewModel> GetAllAcademicLevels()
        {
            var academicLevels = schoolDb.AcademicLevels
                .Where(x => x.IsActive == true)
                .Select(al => new DropDownViewModel() { Id = al.Id, Name = string.Format("{0}", al.Name) })
                .Distinct().ToList();

            return academicLevels;
        }

        public List<DropDownViewModel> GetAllAcademicYears()
        {
            var academicYears = schoolDb.AcademicYears
                .Where(x => x.IsActive == true)
                .Select(ay => new DropDownViewModel() { Id = ay.Id })
                .Distinct().ToList();

            return academicYears;
        }

        public List<DropDownViewModel> GetAllClassCategories()
        {
            var response = new List<DropDownViewModel>();
            var classCategory = new DropDownViewModel() { Id = 1, Name = ClassServiceConstants.CLASS_CATEGORY_PRIMARY };
            response.Add(classCategory);
            classCategory = new DropDownViewModel() { Id = 2, Name = ClassServiceConstants.CLASS_CATEGORY_SECONDARY };
            response.Add(classCategory);
            classCategory = new DropDownViewModel() { Id = 3, Name = ClassServiceConstants.CLASS_CATEGORY_OLEVEL };
            response.Add(classCategory);
            classCategory = new DropDownViewModel() { Id = 4, Name = ClassServiceConstants.CLASS_CATEGORY_ALEVEL_MATHS };
            response.Add(classCategory);
            classCategory = new DropDownViewModel() { Id = 5, Name = ClassServiceConstants.CLASS_CATEGORY_ALEVEL_BIO };
            response.Add(classCategory);
            classCategory = new DropDownViewModel() { Id = 6, Name = ClassServiceConstants.CLASS_CATEGORY_ALEVEL_TECH };
            response.Add(classCategory);
            classCategory = new DropDownViewModel() { Id = 7, Name = ClassServiceConstants.CLASS_CATEGORY_ALEVEL_COMMERCE };
            response.Add(classCategory);
            classCategory = new DropDownViewModel() { Id = 8, Name = ClassServiceConstants.CLASS_CATEGORY_ALEVEL_ART };
            response.Add(classCategory);

            return response;
        }

        public List<DropDownViewModel> GetAllLanguageStreams()
        {
            var response = new List<DropDownViewModel>();
            var languageStream = new DropDownViewModel() { Id = 1, Name = ClassServiceConstants.LANGUAGE_STREAM_SINHALA };
            response.Add(languageStream);
            languageStream = new DropDownViewModel() { Id = 2, Name = ClassServiceConstants.LANGUAGE_STREAM_ENGLISH };
            response.Add(languageStream);
            languageStream = new DropDownViewModel() { Id = 3, Name = ClassServiceConstants.LANGUAGE_STREAM_TAMIL };
            response.Add(languageStream);
            languageStream = new DropDownViewModel() { Id = 4, Name = ClassServiceConstants.LANGUAGE_STREAM_OTHER };
            response.Add(languageStream);

            return response;
        }
    }
}