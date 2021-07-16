using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class MCQAnswer
    {
        public int MCQAnswerID { get; set; }
        public int? QuestionID { get; set; }
        public string  AnswerText { get; set; }
        public int SequenceNo { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Question Question { get; set; }
        
        public virtual ICollection <MCQStudentAnswer> MCQStudentAnswers { get; set; }



    }
}
