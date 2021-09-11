using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
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
            
        }

        public int AcademicYearId { get; set; }
        public int AcademicLevelId { get; set; }
        public int ClassNameId { get; set; }
		public string Name { get; set; }

		public ClassCategory ClassCategoryId { get; set; }
        public LanguageStream LanguageStreamId { get; set; }
        public int ClassTeacherId { get; set; }
        public List<DropDownViewModel> ClassSubjects { get; set; }
        public List<DropDownViewModel> SubjectTeachers { get; set; }


    }


}