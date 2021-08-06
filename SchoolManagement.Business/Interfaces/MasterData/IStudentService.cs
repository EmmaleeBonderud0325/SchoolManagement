using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IStudentService
    {
        List<StudentViewModel> GetAllStudent();
        Task<ResponseViewModel> SaveStudent(StudentViewModel studentView, String userName);
    }
}
