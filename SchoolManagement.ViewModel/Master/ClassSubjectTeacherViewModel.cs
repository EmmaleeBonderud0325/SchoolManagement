using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    class ClassSubjectTeacherViewModel
    {

        public int Id { get; set; }
        public int ClassNameId { get; set; }
        public int AcademicLevelId { get; set; }
        public int AcademicYearId { get; set; }
        public int SubjectId { get; set; }
        public int SubjectTeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

    }
}
