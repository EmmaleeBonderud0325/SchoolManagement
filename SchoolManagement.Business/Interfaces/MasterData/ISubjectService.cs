using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
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
        List<DropDownViewModel> GetAllSubjectStreams();
        List<DropDownViewModel> GetAllAcademicLevels();
        List<DropDownViewModel> GetAllSubjectCategorys();
        public SubjectViewModel GetSubjectbyId(int id);

    }
}
