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

		//public virtual ClassName ClassNameId { get; set; }
		//public virtual AcademicLevel AcademicLevelId { get; set; }
		//public virtual AcademicYear AcademicYearId { get; set; }
	}
}
