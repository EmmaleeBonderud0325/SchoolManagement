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
        Task<ResponseViewModel> AddUser(UserViewModel vm);
    }
}
