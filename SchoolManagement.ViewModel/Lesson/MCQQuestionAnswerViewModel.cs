using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class MCQQuestionAnswerViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string AnswerText { get; set; } 
        public int SequenceNo { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
