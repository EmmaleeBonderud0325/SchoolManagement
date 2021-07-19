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
        public double Marks { get; set; }

        public virtual Question QuestionID { get; set; }
        public virtual User StudentID { get; set; }
        public virtual EssayAnswer EssayAnswerID { get; set; }

        public virtual Question Questions { get; set; }
        public virtual EssayAnswer EssayAnswers { get; set; }
    }
}
