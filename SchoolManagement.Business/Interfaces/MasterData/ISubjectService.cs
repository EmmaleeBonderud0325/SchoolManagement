using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.ViewModel.Master.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface ISubjectService
    {
        List<SubjectViewModel> GetAllSubjects();
        Task<ResponseViewModel> SaveSubject(SubjectViewModel vm, string userName);
        Task<ResponseViewModel> DeleteSubject(int id);
        public SubjectViewModel GetSubjectbyId(int id);
        PaginatedItemsViewModel<BasicSubjectViewModel> GetSubjectList(string searchText, int currentPage, int pageSize);

    }
}
