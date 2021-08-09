using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class MCQQuestionAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string  AnswerText { get; set; }
        public int SequenceNo { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Question Question { get; set; }
        
        public virtual ICollection <MCQQuestionStudentAnswer> MCQQuestionStudentAnswers { get; set; }

        public static object GetAllMCQQuestionAnswers()
        {
            throw new NotImplementedException();
        }

        public static Task SaveMCQQuestionAnswer(MCQQuestionAnswer vm, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
