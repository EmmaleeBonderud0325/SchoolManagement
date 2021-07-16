using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
     public class Lesson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public int VersionNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LearningOutcome{ get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection <Question> Questions { get; set; }

    }
}
