using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    class Lesson
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int OwnerId { get; set; }
        public int VersionNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public String LearningOutcome{ get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public String Status { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
