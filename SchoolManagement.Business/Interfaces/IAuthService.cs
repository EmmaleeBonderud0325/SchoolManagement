using SchoolManagement.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces
{
    public interface IAuthService 
    {
        UserTokenViewModel Login (LoginViewModel model);
    }
}
