using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IClassTeacherService
    {
        Task<ResponseViewModel> SavaClassTeacher(ClassTeacherViewModel vm, string userName);

    }
}
