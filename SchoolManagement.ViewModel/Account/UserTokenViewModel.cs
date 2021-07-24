using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Account
{
    public class UserTokenViewModel
    {
        public UserTokenViewModel()
        {
            Roles = new List<string>();
        }
        public bool IsLoginSuccess { get; set; }
        public string LoginMessage { get; set; }
        public string Token { get; set; }
        public string DisplayName { get; set; }
        public string SchoolDomain { get; set; }
        public List<string> Roles { get; set; }

        

    }
}
