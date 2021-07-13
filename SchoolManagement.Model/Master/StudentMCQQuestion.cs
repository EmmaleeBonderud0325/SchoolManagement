using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class StudentMCQQuestion
    {
        public int QuestionID { get; set; }
        public int StudentID { get; set; }
        public string TeacherComments { get; set; }
        public int  Marks { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public virtual Question QuestionId { get; set; }
        //public virtual User UserId { get; set; }
    }
}
