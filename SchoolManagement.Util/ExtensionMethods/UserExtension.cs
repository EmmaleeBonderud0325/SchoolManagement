using SchoolManagement.Model;
using SchoolManagement.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util.ExtensionMethods
{
    public static class UserExtension
    {
       public static User ToNewModel(this UserViewModel vm, User model = null)
       {
            if(model == null)
            {
                model = new User();
            }

            model.Id = vm.Id;
            model.FullName = vm.FullName;
            model.Email = vm.Email;
            model.MobileNo = vm.MobileNo;
            model.Username = vm.Username;
            model.Address = vm.Address;
                         
            return model;

       }
    }
}
