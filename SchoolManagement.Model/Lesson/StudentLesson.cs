using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class StudentLesson
    {
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public StudentLessonStatus StudentLessonStatus { get; set; }
        public DateTime? JoinedOn { get; set; }
        public DateTime? CompletedOn { get; set; }

        public virtual  Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }


    }
}
