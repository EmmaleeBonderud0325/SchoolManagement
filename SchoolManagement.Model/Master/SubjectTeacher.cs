using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class SubjectTeacher
    {
        public int Id { get; set; }
        public int AcademicLevelId { get; set; }
        public int AcademicYearId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? UpdatedById { get; set; }


        public virtual Subject Subject { get; set; }

        public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        
    }
}
