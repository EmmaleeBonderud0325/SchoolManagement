using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    class Subject
    {
        public int SubjectId { get; set; }
        public String SubjectName { get; set; }
        public String SubjectCode { get; set; }
        public String SubjectCategory { get; set; }
        public bool IsParentBasketSubject { get; set; }
        public bool IsBuscketSubject { get; set; }
        public int ParentBasketSubjectId { get; set; }
        public String SubjectStream { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? UpdatedById { get; set; }

    }
}
