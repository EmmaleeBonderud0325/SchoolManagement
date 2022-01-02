using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class LessonFilterViewModel
    {
        public string searchText { get; set; }
        public int SelectedAcademicYearId { get; set; }
        public int SelectedAcademicLevelId { get; set; }
        public int SelectedClassNameId { get; set; }
        public int SelectedSubjectId { get; set; }
    }
}
