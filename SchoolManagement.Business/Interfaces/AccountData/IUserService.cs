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
        List<UserViewModel> GetAllUsersByRole();
        Task<ResponseViewModel> DeleteUser(int id);
        UserViewModel GetUserbyId(int id);
        UserMasterViewModel GetUserDetail(string userName);
        List<DropDownViewModel> GetAllRoles();
        //List<UserViewModel> GetAllUsersByRole();
        UserMasterDataViewModel GetUserMasterData();
        PaginatedItemsViewModel<BasicUserViewModel> GetUserList(string searchText, int currentPage, int pageSize, int roleId);
        Task<MasterDataUploadResponse> UploadClassStudents(FileContainerViewModel container, string userName);
        List<MasterDataFileValidateResult> ValidateExcelFileContents(string fileSavePath);
        Task<ResponseViewModel> UpdateUserMasterData(UserMasterViewModel vm, string userName);
        //Task<ResponseViewModel> UploadProfilePicture(string userName);
        
    }
}
