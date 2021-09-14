using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    public class ClassMasterDataViewModel
    {
        public ClassMasterDataViewModel()
        {

            AcademicYears = new List<DropDownViewModel>();
            AcademicLevels = new List<DropDownViewModel>();
            ClassNames = new List<DropDownViewModel>();
            ClassCategories = new List<DropDownViewModel>();
            LanguageStreams = new List<DropDownViewModel>();
        }


        public int CurrentAcademicYear { get; set; }
        public List<DropDownViewModel> AcademicYears { get; set; }
        public List<DropDownViewModel> AcademicLevels { get; set; }
        public List<DropDownViewModel> ClassNames { get; set; }
        public List<DropDownViewModel> ClassCategories { get; set; }
        public List<DropDownViewModel> LanguageStreams { get; set; }
        public List<DropDownViewModel> AllTeachers { get; set; }
    }
}
