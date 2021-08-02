using Microsoft.Extensions.Configuration;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class CurrentUserService : ICurrentUserService
    {
       
        private readonly SchoolManagementContext schoolDb;
        public CurrentUserService( SchoolManagementContext schoolDb)
        {
            this.schoolDb = schoolDb;
           
        }

        public User GetUserByUsername(string userName)
        {
            var user = schoolDb.Users.FirstOrDefault(x => x.Username == userName);

            return user;
        }
    }
}
