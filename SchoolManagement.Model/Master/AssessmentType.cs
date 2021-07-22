using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class AssessmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedON { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedON { get; set; }
        public int UpdateByID { get; set; }

        public virtual User CreatedByID { get; set; }
        public virtual User UpdatedByID { get; set; }

      
        public virtual ICollection<AcademicLevelAssessmentType> AcademicLevelAssessmentTypes { get; set; }
    }
}
