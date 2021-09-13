using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    public class SubjectTeacherFilter
    {
        public string SearchText { get; set; }
        public int SelectedAcademicYearId { get; set; }
        public int SelectedAcademicLevelId { get; set; }
    }
}
