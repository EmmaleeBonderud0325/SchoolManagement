using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class MCQStudentAnswer
    {
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
        public int MCQAnswerId { get; set; }
        public string AnswerText { get; set; }
        public int SequnceNo { get; set; }
        public bool IsChecked { get; set; }

        public virtual MCQAnswer  MCQAnswer{ get; set; }
        public virtual  StudentMCQQuestion StudentMCQQuestion{ get; set; }
        public virtual Question Question { get; set; }
        public virtual User Student { get; set; }


    }
}
