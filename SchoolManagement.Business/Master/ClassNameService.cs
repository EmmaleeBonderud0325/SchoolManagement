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
    public class ClassNameService: IClassNameService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public ClassNameService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public async Task <ResponseViewModel> SavaClassName(ClassNameViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

                var className = schoolDb.ClassNames.FirstOrDefault(x => x.Id == vm.Id);

                if (className == null)
                {
                    className = new ClassName()
                    {
                        Id = vm.Id,
                        Name = vm.Name,
                        Description = vm.Description,
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = vm.CreatedById,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = vm.UpdatedById
                    };

                    schoolDb.ClassNames.Add(className);

                    response.IsSuccess = true;
                    response.Message = "Class Name Added Successfull.";
                }
                else
                {
                    className.Name = vm.Name;
                    className.Description = vm.Description;
                    className.IsActive = true;
                    className.UpdatedOn = DateTime.UtcNow;
                    className.UpdatedById = vm.UpdatedById;

                    schoolDb.ClassNames.Update(className);
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