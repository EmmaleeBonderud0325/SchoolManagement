using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class Class
    {
		public int ClassNameId { get; set; }
		public int AcademicLevelId { get; set; }
		public int AcademicYearId { get; set; }
		public string Name { get; set; }
		public string ClassCategory { get; set; }
		public string LanguageStream { get; set; }

		public virtual ClassName ClassName { get; set; }
		public virtual AcademicLevel AcademicLevel { get; set; }
		public virtual AcademicYear AcademicYear { get; set; }

		public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
		public virtual ICollection<ClassTeacher> ClassTeacher { get; set; }
		public virtual ICollection<StudentClass> StudentClasses { get; set; }
	}
}
