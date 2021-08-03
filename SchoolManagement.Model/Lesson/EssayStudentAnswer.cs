using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class EssayStudentAnswer
    {
        public int QuestionId { get; set;}
        public int StudentId { get; set; }
        public int AnswerText { get; set; }
        //public int EssayQuestionAnswerId { get; set; }
        public string TeacherComments { get; set; }
        public decimal Marks { get; set; }

        public virtual Question Question{ get; set; }
        public virtual User Student { get; set; }
      
    }
}
