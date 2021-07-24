using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class StudentLessonTopic
    {
        public int TopicId { get; set; }
        public int StudentId { get; set; }
        public StudentLessonTopicStatus StudentLessonTopicStatus { get; set; }
        public DateTime? JoinedOn { get; set; }
        public DateTime? CompletedOn { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual Student Student { get; set; }
    }
}
