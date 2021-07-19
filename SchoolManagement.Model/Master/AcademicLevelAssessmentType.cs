using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class AcademicLevelAssessmentType
    {
        public int AssessmentTypeId { get; set; }
        public int AcademicLevelId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedById { set; get; }
        public DateTime UpdatedOn { get; set; }
        public int? UpdatedById { get; set; }

        public  virtual EssayStudentAnswer AssessmentTypeiD { get; set; }
        public virtual AcademicLevel AcademicLevel { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public virtual EssayStudentAnswer AssessmentType { get; set; }
        public virtual AcademicLevel AcademicLevels { get; set; }
        public virtual AssessmentType AssessmentTypes { get; set; }
    }
}
