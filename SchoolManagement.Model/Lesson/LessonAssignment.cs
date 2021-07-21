using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class LessonAssignment
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Descripstion { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedByOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedById { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual ICollection<LessonAssignmentSubmission> LessonAssignmentSubmissions { get; set; }
    }
}
