using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class EssayStudentAnswer
    {
        public int AssessmentTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedById { set; get; }
        public  DateTime UpdatedOn { get; set; }
        public int? UpdatedById { set; get; }

        public virtual User CreatedBy { set; get; }
        public virtual User UpdatedBy { set; get; }

        public virtual  ICollection<AcademicLevelAssessmentType> AcademicLevelAssesmentTypes { get; set; }
        public object EssayStudentAnswers { get; set; }
    }
}
