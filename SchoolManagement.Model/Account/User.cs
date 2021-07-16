using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Account
{
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public byte ProfileImage { get; set; }
        public string Address { get; set; }
        public int LoginSessionId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<User> CreatedUsers { get; set; }
        public virtual ICollection<User> UpdatedUsers { get; set; }
        public virtual ICollection<UserRole> CreatedUserRoles { get; set; }
        public virtual ICollection<UserRole> UpdatedUserRoles { get; set; }

        public virtual ICollection<ClassName> ClassName { get; set; }
        public virtual ICollection<ClassTeacher> ClassTeacher { get; set; }



    }
}
