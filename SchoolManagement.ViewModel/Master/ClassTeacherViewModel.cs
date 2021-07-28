using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    class ClassTeacherViewModel
    {
		public string ClassNameId { get; set; }
		public string AcademicLevelId { get; set; }
		public string AcademicYearId { get; set; }
		public string TeacherId { get; set; }
		public bool IsPrimary { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedOn { get; set; }
		public int? CreatedById { get; set; }
		public DateTime UpdatedOn { get; set; }
		public int? UpdatedById { get; set; }
	}
}
