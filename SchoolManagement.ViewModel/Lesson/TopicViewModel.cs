using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    class TopicViewModel
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Name { get; set; }
        public int SequenceNo { get; set; }
        public string LearningExperience { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
