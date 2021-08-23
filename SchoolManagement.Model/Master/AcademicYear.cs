using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
   public class AcademicYear
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }


        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; }
    }
}
