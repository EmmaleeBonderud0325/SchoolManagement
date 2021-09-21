using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class LessonContainer
    {
       
    }

    public class LessonVM
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int AcademicYearId { get; set; }
    }
    public class LessonObjective
    {
        public int Id { get; set; }
        public string LessonId { get; set; }

    }

}
