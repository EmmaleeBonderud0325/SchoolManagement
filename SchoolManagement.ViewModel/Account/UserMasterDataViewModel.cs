using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Account
{
    public class UserMasterDataViewModel
    {
        public UserMasterDataViewModel()
        {
            UserRoles = new List<DropDownViewModel>();
            AcademicLevels = new List<DropDownViewModel>();
        }
        public List<DropDownViewModel> UserRoles { get; set; }
        public List<DropDownViewModel> AcademicLevels { get; set; }
        
    }
}
