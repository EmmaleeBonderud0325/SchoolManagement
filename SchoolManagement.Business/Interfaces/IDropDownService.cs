using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces
{
    public interface IDropDownService
    {
        //Sucject Service Dropdouwn Service
        List<DropDownViewModel> GetSubjectTypes();
        List<DropDownViewModel> GetAllSubjectCategorys();
        List<DropDownViewModel> GetAllParentBasketSubjects();
    }
}
