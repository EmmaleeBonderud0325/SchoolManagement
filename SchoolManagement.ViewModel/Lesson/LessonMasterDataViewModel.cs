using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class LessonMasterDataViewModel
    {
        public LessonMasterDataViewModel()
        {
            AcademicLevels = new List<DropDownViewModel>();
            ClassNames = new List<DropDownViewModel>();
            AcademicYears = new List<DropDownViewModel>();
            Subjects = new List<DropDownViewModel>();
        }
        public List<DropDownViewModel> AcademicLevels { get; set; }
        public List<DropDownViewModel> ClassNames { get; set; }
        public List<DropDownViewModel> AcademicYears { get; set; }
        public List<DropDownViewModel> Subjects { get; set; }
    }
}
