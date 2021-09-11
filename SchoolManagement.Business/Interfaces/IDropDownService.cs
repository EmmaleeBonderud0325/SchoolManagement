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
        //common Services
        List<DropDownViewModel> GetAllAcademicLevels();

        //Sucject Dropdouwn Service
        List<DropDownViewModel> GetSubjectTypes();
        List<DropDownViewModel> GetAllSubjectCategorys();
        List<DropDownViewModel> GetAllParentBasketSubjects();
        List<DropDownViewModel> GetAllSubjectStreams();

        //Class Drop Down Service
        List<DropDownViewModel> GetAllClassNames();
        List<DropDownViewModel> GetAllAcademicYears();
        List<DropDownViewModel> GetAllClassCategories();
        List<DropDownViewModel> GetAllLanguageStreams();
        List<DropDownViewModel> GetAllTeachers();
    }
}
