using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class Question
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int TopicId { get; set; }
        public int SequnceNo { get; set; }
        public string QuestionText { get; set; }
        public decimal Marks { get; set; }
        public QuestionLevel QuestionLevel { get; set; }
        public QuestionType QuestionType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedById { get; set; }

        public virtual Lesson Lesson{ get; set; }
        public virtual Topic Topic { get; set; }

        public virtual ICollection <MCQAnswer> MCQAnswers{ get; set; }
        public virtual ICollection <StudentMCQQuestion> StudentMCQQuestions { get; set; }

        public virtual  ICollection <EssayAnswer> EssayAnswers { get; set; }
        public virtual  ICollection <EssayStudentAnswer> EssayStudentAnswers{ get; set; }
        public virtual ICollection<MCQStudentAnswer> MCQStudentAnswers { get; set; }

    }
}
