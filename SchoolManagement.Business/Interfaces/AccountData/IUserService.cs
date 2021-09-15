using SchoolManagement.Model;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.AccountData
{
    public interface IUserService
    {
        Task<ResponseViewModel> SaveUser(UserViewModel vm, string userName);
        List<UserViewModel> GetAllUsersByRole(/*DropDownViewModel vm*/);
        Task<ResponseViewModel> DeleteUser(int id);
        UserViewModel GetUserbyId(int id);
        List<DropDownViewModel> GetAllRoles();
        //List<UserViewModel> GetAllUsersByRole();
        UserMasterDataViewModel GetUserMasterData();
        PaginatedItemsViewModel<BasicUserViewModel> GetUserList(string searchText, int currentPage, int pageSize, int roleId);



    }
}
