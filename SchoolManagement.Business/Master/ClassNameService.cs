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
        private readonly ICurrentUserService currentUserService;

        public ClassNameService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<ClassNameViewModel> GetAllClassNames()
        {
            var response = new List<ClassNameViewModel>();

            var query = schoolDb.ClassNames.Where(u => u.IsActive == true);

            var ClassNameList = query.ToList();

            foreach (var classname in ClassNameList)
            {
                var vm = new ClassNameViewModel
                {
                    Id = classname.Id,
                    Name = classname.Name,
                    Description = classname.Description,
                    IsActive = classname.IsActive,
                    CreatedOn = classname.CreatedOn,
                    CreatedById = classname.CreatedById,
                    UpdatedOn = classname.UpdatedOn,
                    UpdatedById = classname.UpdatedById,
                };

                response.Add(vm);
            }

            return response;
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