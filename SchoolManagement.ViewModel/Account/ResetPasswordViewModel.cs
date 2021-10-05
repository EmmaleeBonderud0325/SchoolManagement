using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Account
{
    public class ResetPasswordViewModel
    {
        public string SchoolDomain { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string COnfirmPassword { get; set; }
    }
}
