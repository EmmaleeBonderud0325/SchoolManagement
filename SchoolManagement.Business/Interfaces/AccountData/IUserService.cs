using SchoolManagement.Model;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.AccountData
{
    public interface IUserService
    {
        Task<ResponseViewModel> SaveUser(UserViewModel vm, string userName);
        List<UserViewModel> GetAllUsers();
        Task<ResponseViewModel> DeleteUser(int id);

    }
}
