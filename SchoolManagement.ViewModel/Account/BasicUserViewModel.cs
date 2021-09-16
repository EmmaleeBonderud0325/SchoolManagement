using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Account
{
    public class BasicUserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedByName { get; set; }
    }
}
