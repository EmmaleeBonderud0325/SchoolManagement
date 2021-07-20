using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class EssayStudentAnswer
    {
        public int QuestionId { get; set;}
        public int StudentId { get; set; }
        public int? EssayAnswerId { get; set; }
        public int AnswerText { get; set; }
        public string TeacherComments { get; set; }
        public decimal Marks { get; set; }

        public virtual Question Question{ get; set; }
        public virtual User Student { get; set; }
        public virtual EssayAnswer EssayAnswer { get; set; }

        public virtual Question Questions { get; set; }
        public virtual EssayAnswer EssayAnswers { get; set; }
    }
}
