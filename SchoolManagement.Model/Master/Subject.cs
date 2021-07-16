using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectCategory { get; set; }
        public bool IsParentBasketSubject { get; set; }
        public bool IsBuscketSubject { get; set; }
        public int ParentBasketSubjectId { get; set; }
        public string SubjectStream { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? UpdatedById { get; set; }

        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        public virtual ICollection<SubjectAcademicLevel> SubjectAcademicLevels { get; set; }
        public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; } //sasanka
    }
}
