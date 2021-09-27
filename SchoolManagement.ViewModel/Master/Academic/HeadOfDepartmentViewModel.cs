using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    public class HeadOfDepartmentViewModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int AcademicLevelId { get; set; }
        public string AcademicLevelName { get; set; }
        public int AcademicYearId { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedByName { get; set; }
    }
}
