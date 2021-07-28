using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.AccountData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.Util;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class UserService: IUserService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public UserService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public async Task<ResponseViewModel> SaveUser(UserViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {               
                var user = schoolDb.Users.FirstOrDefault(x => x.Id == vm.Id);

                if(user == null)
                {
                    var managementLevelUser = new User()
                    {
                        Id = vm.Id,
                        FullName = vm.FullName,
                        Email = vm.Email,
                        MobileNo = vm.MobileNo,
                        Username = vm.Username,
                        Address = vm.Address,
                        Password = CustomPasswordHasher.GenerateHash(vm.Password),
                        IsActive = true,
                        CreatedOn = DateTime.UtcNow,
                    };

                    response.IsSuccess = true;
                    response.Message = "Mangement Level User Added Successfull.";

                    schoolDb.Users.Add(managementLevelUser);
                    await schoolDb.SaveChangesAsync();
                }
                else
                {

                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }

        //public async Task<ResponseViewModel> SaveUser(UserViewModel vm, )
        //{
        //    var response = new ResponseViewModel();

        //    try
        //    {
        //        var managementLevelUser = new User()

        //        {
        //            Id = vm.Id,
        //            FullName = vm.FullName,
        //            Email = vm.Email,
        //            MobileNo = vm.MobileNo,
        //            Username = vm.Username,
        //            Address = vm.Address,
        //            Password = CustomPasswordHasher.GenerateHash(vm.Password),
        //            IsActive = true,
        //            CreatedOn = DateTime.UtcNow,


        //        };

        //        schoolDb.Users.Add(managementLevelUser);
        //        await schoolDb.SaveChangesAsync();

        //        response.IsSuccess = true;
        //        response.Message = "Mangement Level User Added Successfull.";

        //    }
        //    catch(Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = ex.ToString();
        //    }

        //    return response;
        //}
    }
}
