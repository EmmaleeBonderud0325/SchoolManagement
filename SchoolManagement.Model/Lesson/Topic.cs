using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class Topic
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Name { get; set; }
        public int SequenceNo { get; set; }
        public string LearningExperience { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn{ get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual ICollection<TopicContent>TopicContents { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<StudentLessonTopic> StudentLessonTopics { get; set; }

    }
}
