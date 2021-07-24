using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Util;
using SchoolManagement.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class AuthService : IAuthService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;


        public AuthService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }
        public UserTokenViewModel Login(LoginViewModel model)
        {
            var response = new UserTokenViewModel();

            //Find the user using username and user should be active;
            var user = schoolDb.Users.Where(x => x.IsActive == true).FirstOrDefault(u => u.Username == model.Username);
            //if user is null. Then return response with propert error messsage;
            if(user == null)
            {
                response.LoginMessage = "User Not Found";
            }
            //Else match password with Password hasher.
            else
            {
                user.Password = CustomPasswordHasher.GenerateHash(model.Password);
            }

            return response;
        }
    }
}
