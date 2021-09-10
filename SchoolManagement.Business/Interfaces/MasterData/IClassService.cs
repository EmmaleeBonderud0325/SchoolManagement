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
        List<ClassViewModel> GetClasses();
        Task<ResponseViewModel> SavaClass(ClassViewModel classVM, string userName);
        Task<ResponseViewModel> DeleteClass(int id);
       
    }
}
