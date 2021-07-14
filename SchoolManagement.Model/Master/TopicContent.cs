using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    class TopicContent
    {
        public int ID { get; set; }
        public String Introduction { get; set; }
        public int ContentType { get; set; }
        public String Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
