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

        public List<UserViewModel> GetAllUsers()
        {
            var response =  new List<UserViewModel>();

            var query = schoolDb.Users.Where(u => u.IsActive == true);

            var UserList = query.ToList();

            foreach(var user in UserList)
            {
                var vm = new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Username = user.Username,
                    Address = user.Address,
                    Email = user.Email,
                    MobileNo = user.MobileNo,
                    
                };

                response.Add(vm);
            }

            return response;
        }

        //public User GetUserByUsername(string userName)
        // {
        //     var user = schoolDb.Users.FirstOrDefault(x => x.Username.ToLower() == userName.ToLower());

        //     return user;
        // }

        public async Task<ResponseViewModel> SaveUser(UserViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = schoolDb.Users.FirstOrDefault(x => x.Username.Trim().ToUpper() == userName.Trim().ToUpper());

                var user = schoolDb.Users.FirstOrDefault(x => x.Id == vm.Id);
              
                var getUserRoles = schoolDb.Roles.FirstOrDefault(x => x.IsActive == true);
             

                if (user == null)
                {
                    user = new User()
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
                        CreatedById = loggedInUser.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = loggedInUser.Id
                    };

                    user.UserRoles = new HashSet<UserRole>();

                    foreach (var item in vm.Roles.Where(x=>x.IsCheck))
                    {
                        var userRole = new UserRole()
                        {
                            RoleId = item.Id,
                            IsActive = true,
                            CreatedById = loggedInUser.Id,
                            CreatedOn=DateTime.UtcNow,
                            UpdatedById= loggedInUser.Id,
                            UpdatedOn= DateTime.UtcNow
                        };

                        user.UserRoles.Add(userRole);
                    }

                    schoolDb.Users.Add(user);

                    response.IsSuccess = true;
                    response.Message = "Mangement Level User Added Successfull.";                    
                }
                else
                {
                    user.Address = vm.Address;
                    user.FullName = vm.FullName;
                    user.Email = vm.Email;
                    user.MobileNo = vm.MobileNo;
                    user.UpdatedById = loggedInUser.Id;
                    user.UpdatedOn = DateTime.UtcNow;

                    var existingRoles = user.UserRoles.ToList();
                    var selectedRols = vm.Roles.Where(x => x.IsCheck).ToList();

                    var newRoles = (from r in selectedRols where !existingRoles.Any(x => x.RoleId == r.Id) select r).ToList();

                    var deletedRoles = (from r in existingRoles where selectedRols.Any(x => x.Id == r.RoleId) select r).ToList();

                    foreach (var item in newRoles)
                    {
                        var userRole = new UserRole()
                        {
                            RoleId = item.Id,
                            IsActive = true,
                            CreatedById = loggedInUser.Id,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedById = loggedInUser.Id,
                            UpdatedOn = DateTime.UtcNow
                        };   

                        user.UserRoles.Add(userRole);
                    }

                    foreach(var deletedRole in deletedRoles)
                    {
                        user.UserRoles.Remove(deletedRole);
                    }

                    schoolDb.Users.Update(user);

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
