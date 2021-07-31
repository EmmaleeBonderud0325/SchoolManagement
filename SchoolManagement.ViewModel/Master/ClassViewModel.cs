using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
	public class ClassViewModel
	{
		public int ClassNameId { get; set; }
		public int AcademicLevelId { get; set; }
		public int AcademicYearId { get; set; }
		public string Name { get; set; }
		public ClassCategory ClassCategory { get; set; }
		public LanguageStream LanguageStream { get; set; }
	}
}