using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class AssessmentType
    {
        public int AssessmentTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedON { get; set; }
        public int? CreatedByID { get; set; }
        public DateTime UpdatedON { get; set; }
        public int? UpdatedON { get; set; }
    }
}
