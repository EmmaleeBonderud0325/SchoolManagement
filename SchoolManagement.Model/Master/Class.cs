using SchoolManagement.Model.Account;
using SchoolManagement.Util.Enums;
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
		public ClassCategory ClassCategory { get; set; }
		public string LanguageStream { get; set; }
		public int CreatedById { get; set; }
		public DateTime UpdatedOn { get; set; }
		public int UpdatedById { get; set; }

		public virtual User CreatedBy { get; set; }
		public virtual User UpdatedBy { get; set; }

		public virtual ClassName ClassName { get; set; }
		public virtual AcademicLevel AcademicLevel { get; set; }
		public virtual AcademicYear AcademicYear { get; set; }

		public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
		public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
		public virtual ICollection<StudentClass> StudentClasses { get; set; }
		public virtual ICollection<Lesson> Lessons { get; set; }
	}
}
