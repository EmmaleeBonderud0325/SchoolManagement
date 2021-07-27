using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class TopicContent
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Introduction { get; set; }
        public TopicContentType ContentType { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Topic Topic { get; set; }

        public  virtual ICollection<StudentLessonTopicContent> StudentLessonTopicContents { get; set; }

    }
}
