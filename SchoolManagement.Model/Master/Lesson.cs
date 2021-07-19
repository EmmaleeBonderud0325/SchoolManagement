using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class Lesson
    {
        private StudentClassSubject academicLevelID;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public int? AcademicLevelID { get; set; }
        public int? ClassNameID { get; set; }
        public int? AcademicYearID { get; set; }
        public int VersionNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedByID { get; set; }
        public string LearningOutcome { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? UpdatedByID { get; set; }

        //public virtual StudentClassSubject AcademicLevelId { get; set; }
        public virtual Class ClassNameId { get; set; }

        //public virtual StudentClassSubject AcademicYearId { get; set; }
         public virtual Subject SubjectID { get; set; }
        //public virtual  SubjectTeacher CreatedById { get; set; }
       // public virtual ClassSubjectTeacher CreatedById{ get; set; }
       public virtual SubjectTeacher UpdatedById { get; set; }
        //public virtual ClassSubjectTeacher UpdatedById { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Question>Questions{ get; set; }
    }

}
