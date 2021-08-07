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
        List<ClassViewModel> GetAllClasses();
        Task<ResponseViewModel> SavaClass(ClassViewModel vm, string userName);
        Task<ResponseViewModel> DeleteClass(int id);
    }
}
