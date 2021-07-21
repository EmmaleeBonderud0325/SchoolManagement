using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class StudentMCQQuestion
    {
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
        public string TeacherComments { get; set; }
        public decimal  Marks { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public virtual Question Question { get; set; }
        public virtual User Student { get; set; }
       
        public virtual ICollection <MCQStudentAnswer> MCQStudentAnswers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
