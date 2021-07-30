using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class QuestionViewModel
    {
        public  QuestionViewModel() 
        {
            QuestionType = new List<string>();
            DifficultyLevel = new List<string>();
        }
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int? TopicId { get; set; }
        public int SequnceNo { get; set; }
        public string QuestionText { get; set; }
        public decimal Marks { get; set; }
        public List<string> DifficultyLevel { get; set; }
        public List<string>QuestionType  { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedById { get; set; }
    }
}
