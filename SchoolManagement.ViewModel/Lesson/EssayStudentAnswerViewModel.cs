using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class EssayStudentAnswerViewModel
    {
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
        public int EssayQuestionAnswerId { get; set; }
        public string AnswerText { get; set; }
        public string TeacherComments { get; set; }
        public decimal Marks { get; set; }
    }
}
