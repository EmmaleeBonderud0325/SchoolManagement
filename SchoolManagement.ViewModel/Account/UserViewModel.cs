using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
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
            Roles = new List<int>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public List<int> Roles { get; set; }

        public DateTime CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedByName { get; set; }
        public int? UpdatedById { get; set; }
    }

    public class StudentExcelContainer
    {

        public StudentExcelContainer()
        {
            Students = new List<UserViewModel>();
        }
        public int AcademicYear { get; set; }
        public int AcademicLevelId { get; set; }
        public int ClassId { get; set; }
        public int ClassTeacherId { get; set; }

        public List<UserViewModel> Students { get; set; }
    }
}
