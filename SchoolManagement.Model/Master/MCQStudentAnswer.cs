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
        public int QuestionID { get; set; }
        public int StudentID { get; set; }
        public int? MCQAnswerID { get; set; }
        public string AnswerText { get; set; }
        public int SequnceNo { get; set; }
        public bool IsChecked { get; set; }

        public virtual MCQAnswer  MCQAnswer{ get; set; }
        public virtual  StudentMCQQuestion StudentMCQQuestion{ get; set; }
        
    }
}
