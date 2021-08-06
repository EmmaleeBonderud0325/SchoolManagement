using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IHeadOfDepartmentService
    {
        List<HeadOfDepartmentViewModel> GetAllHeadOfDepartment();
    }
}
