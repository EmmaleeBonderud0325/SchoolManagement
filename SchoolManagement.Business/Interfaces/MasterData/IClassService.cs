using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
  public interface IClassService
  {
    PaginatedItemsViewModel<BasicClassViewModel> GetClassList(string searchText, int currentPage, int pageSize, int academicYearId, int academicLevelId);
    ClassViewModel GetClassDetails(int academicYearId, int academicLevelId, int classNameId);
    List<ClassSubjectTeacherViewModel> GetClassSubjectsForSelectedAcademiclevel(int academicYearId,int academicLevelId);
    Task<ResponseViewModel> SaveClassDetail(ClassViewModel vm, string userName);
    ClassMasterDataViewModel GetClassMasterData();
    Task<ResponseViewModel> DeleteClass(int academicYearId, int academicLevelId, int classNameId, string username);

  }
}
