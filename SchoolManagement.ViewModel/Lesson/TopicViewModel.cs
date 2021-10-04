using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
     public class TopicViewModel
    {
        public TopicViewModel()
        {
            TopicContents = new List<TopicContentViewModel>();
        }

        public int Id { get; set; }
        public int LessonId { get; set; }
        public DropDownViewModel Lesson { get; set; }
        public string Name { get; set; }
        public int SequenceNo { get; set; }
        public string LearningExperience { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

    public bool Editable { get; set; }

    public List<TopicContentViewModel> TopicContents { get; set; }
    }
}
