using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class BasicQuestionViewModel
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int? TopicId { get; set; }
        public string TopicName { get; set; }
        public int SequenceNo { get; set; }
        public string QuestionText { get; set; }
        public string QuestionName { get; set; }
        public decimal Marks { get; set; }        
        public string QuestionTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedByName { get; set; }
    }
}
