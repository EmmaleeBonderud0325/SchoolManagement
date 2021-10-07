using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.ViewModel.Master.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IHeadOfDepartmentService
    {
        List<HeadOfDepartmentViewModel> GetAllHeadOfDepartment();
        Task<ResponseViewModel> SaveHeadOfDepartment(HeadOfDepartmentViewModel HeadOfDepartmentVM, String userName);
        Task<ResponseViewModel> DeleteHeadOfDepartment(int id);
        List<DropDownViewModel> GetAllAcademicYears();
        List<DropDownViewModel> GetAllAcademicLevels();
        List<DropDownViewModel> GetAllSubjects();
        List<DropDownViewModel> GetAllTeachers();
        PaginatedItemsViewModel<BasicHeadOfDepartmentViewModel> GetHeadOfDepartmentList(string searchText, int currentPage, int pageSize);
        public DownloadFileModel downloadHeadOfDepartmentListReport();
    }
}
