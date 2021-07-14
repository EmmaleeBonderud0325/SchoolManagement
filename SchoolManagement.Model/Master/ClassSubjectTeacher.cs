using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    class ClassSubjectTeacher
    {
        public int classsubjectTeacherId { get; set; }
        public int classNameId  { get; set; }
        public int academicLevelId { get; set; }
        public int academicYearId { get; set; }
        public int subjectId { get; set; }
        public int subjectTeacherId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isActive { get; set; }
        public DateTime createdOn { get; set; }
        public int createdById { get; set; }
        public DateTime updatedOn { get; set; }
        public int UpdatedById { get; set; }
    }
}
