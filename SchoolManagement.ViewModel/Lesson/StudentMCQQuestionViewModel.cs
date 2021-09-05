using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class StudentMCQQuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestioinName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string TeacherComments { get; set; }
        public decimal Marks { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
