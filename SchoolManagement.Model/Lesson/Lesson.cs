using SchoolManagement.Model.Account;
using SchoolManagement.Util.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public int AcademicLevelId { get; set; }
        public int ClassNameId { get; set; }
        public int AcademicYearId { get; set; }
        public int SubjectId { get; set; }
        public int VersionNo { get; set; }
        public string LearningOutcome { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public LessonStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedById { get; set; }

        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual User Owner { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }


        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Question>Questions{ get; set; }
        public virtual ICollection<LessonAssignment> LessonAssignments { get; set; }

        
    }

}
