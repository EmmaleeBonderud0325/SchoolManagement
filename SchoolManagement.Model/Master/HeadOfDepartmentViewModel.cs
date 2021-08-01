using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class HeadOfDepartmentViewModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int AcademicLevelId { get; set; }
        public int AcademicYearId { get; set; }
        public int TeacherId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedById { get; set; }
    }
}
