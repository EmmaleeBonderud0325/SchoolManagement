using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util.Enums
{
    public enum SubjectCategory
    {
        [Description("Primary School Subject")]
        PrimarySchoolSubject = 1,
        [Description("Junior School Subject")]
        JuniorSchoolSubject = 2,
        [Description("High School Subject")]
        HighSchoolSubject = 3
    }
}
