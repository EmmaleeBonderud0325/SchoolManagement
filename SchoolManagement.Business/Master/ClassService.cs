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
    public class ClassService: IClassService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public ClassService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public async Task <ResponseViewModel> SavaClass(ClassViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

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
                        LanguageStream = vm.LanguageStream
                    };

                    schoolDb.Classes.Add(classes);

                    response.IsSuccess = true;
                    response.Message = "Class is Added Successfull.";
                }
                else
                {
                    classes.Name = vm.Name;
                    classes.ClassCategory = vm.ClassCategory;
                    classes.LanguageStream = vm.LanguageStream;
                    classes.UpdatedOn = DateTime.UtcNow;
                    classes.UpdatedById = vm.UpdatedById;

                    schoolDb.Classes.Update(classes);
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
