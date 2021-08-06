using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface ISubjectStreamService
    {
        Task<ResponseViewModel> SaveSubjectStream(SubjectStreamViewModel vm, string userName);
        List<SubjectStreamViewModel> GetAllSubjectStream();
        Task<ResponseViewModel> DeleteSubjectStream(int id);
    }
}
