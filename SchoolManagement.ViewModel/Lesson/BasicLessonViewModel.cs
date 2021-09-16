using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class BasicLessonViewModel
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public string AcademicLevelId { get; set; }
        public string ClassName { get; set; }
        public int AcademicYearId { get; set; }
        public string SubjectName { get; set; }
       
    }
}
