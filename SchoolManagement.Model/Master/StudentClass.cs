using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
      public class StudentClass
    {
        public int StudentId { get; set; }
        public int ClassNameId { get; set; }
        public int AcademicYearId { get; set; }
        public int AcademicLevelId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }

        public virtual ICollection<StudentClassSubject> StudentClassSubjects { get; set; }



    }
}
