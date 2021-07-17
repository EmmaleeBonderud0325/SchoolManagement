using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class AcademicLevel
    {
        public int AcademicLevelId { get; set; }
        public string Name { get; set; }
        public int LevelHeadId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }


        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual ICollection<SubjectAcademicLevel> SubjectAcademicLevels { get; set; }
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<AcademicLevelAssessmentType> AcademicLevelAssessmentType { get; set; }
        public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; }
    
    }
}
