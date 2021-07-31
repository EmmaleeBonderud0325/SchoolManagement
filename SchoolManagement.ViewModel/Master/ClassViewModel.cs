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
		public ClassViewModel()
		{
			ClassCategory = new List<string>();
			LanguageStream = new List<string>();
		}
		public int ClassNameId { get; set; }
		public int AcademicLevelId { get; set; }
		public int AcademicYearId { get; set; }
		public string Name { get; set; }
		public List<string> ClassCategory { get; set; }
		public List<string> LanguageStream { get; set; }
	}
}