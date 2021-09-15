using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    public class BasicClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public int AcademicLevelId { get; set; }
        public int ClassNameId { get; set; }
        public string ClassTeacherName { get; set; }
        public int TotalStudentCount { get; set; }
    }
}
