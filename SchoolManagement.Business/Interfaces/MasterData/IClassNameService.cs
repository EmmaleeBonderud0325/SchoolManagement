using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IClassNameService
    {
        List<ClassNameViewModel> GetClassNames();
        Task<ResponseViewModel> SavaClassName(ClassNameViewModel classNameVM, string userName);
        Task<ResponseViewModel> DeleteClassName(int id);
    }
}