using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class LessonAssignmentSubmission
    {
        public int Id { get; set; }
        public int LessonAssignmentId { get; set; }
        public int StudentId { get; set; }
        public string SubmissionPath { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal Marks { get; set; }
        public string TeacherComments { get; set; }

        public LessonAssignment LessonAssignment { get; set; }
        public User Student { get; set; }
    }
}
