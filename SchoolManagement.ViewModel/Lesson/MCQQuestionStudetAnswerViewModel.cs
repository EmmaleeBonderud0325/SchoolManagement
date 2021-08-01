using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class MCQQuestionStudetAnswerViewModel
    {
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
        public int MCQQuestionAnswerId { get; set; }
        public string AnswerText { get; set; }
        public int SequnceNo { get; set; }
        public bool IsChecked { get; set; }
    }
}
