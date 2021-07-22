using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class StudentLessonTopicContenet
    {
        public int TopicContentId { get; set; }
        public int StudentId { get; set; }
        public StudentLessonTopicStatus StudentLessonTopicStatus { get; set; }
        public DateTime? JoinedOn { get; set; }
        public DateTime? CompletedOn { get; set; }

        public virtual TopicContent TopicContent { get; set; }
        public virtual Student Student { get; set; }
    }
}
