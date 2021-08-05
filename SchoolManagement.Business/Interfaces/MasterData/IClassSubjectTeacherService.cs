using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IClassSubjectTeacherService
    {
        List<ClassSubjectTeacherViewModel> GetAllClassSubjectTeachers();
        Task<ResponseViewModel> SaveClassSubjectTeacher(ClassSubjectTeacherViewModel vm, string userName);
        Task<ResponseViewModel> DeleteClassSubjectTeacher(int id);

    }
}
