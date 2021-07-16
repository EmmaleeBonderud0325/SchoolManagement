using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int? LessonID { get; set; }
        public int? TopicID { get; set; }
        public int SequnceNo { get; set; }
        public string QuestionText { get; set; }
        public int Marks { get; set; }
        public int QuestionLevel { get; set; }
        public string QuestionType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }

        public virtual Lesson Lesson{ get; set; }
        public virtual Topic Topic { get; set; }

        public virtual ICollection <MCQAnswer> MCQAnswers{ get; set; }
        public virtual ICollection <StudentMCQQuestion> StudentMCQQuestions { get; set; }

        public virtual  ICollection <EssayAnswer> EssayAnswers { get; set; }
        public virtual  ICollection <EssayStudentAnswer> EssayStudentAnswers{ get; set; }

    }
}
