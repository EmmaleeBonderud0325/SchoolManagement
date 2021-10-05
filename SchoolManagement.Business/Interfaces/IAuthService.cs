using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
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
        ResponseViewModel ForgotPassword(ForgotPasswordViewModel vm);
    }
}
