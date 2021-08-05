using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface ISubjectTeacherService
    {
        List<SubjectTeacherViewModel> GetAllSubjectTeachers();
        Task<ResponseViewModel> SaveSubjectTeacher(SubjectTeacherViewModel vm, string userName);
        Task<ResponseViewModel> DeleteSubjectTeacher(int id);

    }
}
