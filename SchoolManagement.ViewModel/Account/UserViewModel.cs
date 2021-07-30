using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Account
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles = new List<RoleViewModel>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public string LastLoginDate { get; set; }
       // public byte ProfileImage { get; set; }
        public string Address { get; set; }
       // public int LoginSessionId { get; set; }
        public bool IsActive { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public int? CreatedById { get; set; }
        //public DateTime UpdatedOn { get; set; }
        //public int? UpdatedById { get; set; }
    }
}
