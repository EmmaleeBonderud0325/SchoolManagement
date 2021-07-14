using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    class Topic
    {
        public int TopicID { get; set; }
        public String Name { get; set; }
        public int SequenceNo { get; set; }
        public String LearningExperience { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn{ get; set; }
    }
}
