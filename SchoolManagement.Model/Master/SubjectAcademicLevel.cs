using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class SubjectAcademicLevel
    {
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }


        public int AcademicLevelId { get; set; }
        public virtual AcademicLevel AcademicLevel { get; set; }


    }
}
