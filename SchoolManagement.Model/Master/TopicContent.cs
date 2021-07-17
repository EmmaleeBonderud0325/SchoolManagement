using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class TopicContent
    {
        public int ID { get; set; }
        public int? TopicID { get; set; }
        public string Introduction { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Topic TopicId { get; set; }
    }
}
