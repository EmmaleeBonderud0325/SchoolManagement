using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class BasicLessonAssignmnetSubmissionViewModel
    {
        public int Id { get; set; }
        public int LessonAssignmentId { get; set; }
        public string LessonAssignmentName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string SubmissionPath { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal Marks { get; set; }
        public string TeacherComments { get; set; }

    }
}
