using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Common.Enums
{
    public enum RoleType
    {
        [Description("Supper Admin")]
        SupperAdmin = 1,
        [Description("Admin")]
        Admin = 2,
        [Description("Principle")]
        Principle = 3,
        [Description("Level Head")]
        LevelHead = 4,
        [Description("Head Of Deaprtment")]
        HOD = 5,
        [Description("Teacher")]
        Teacher = 6,
        [Description("Student")]
        Student = 7,
        [Description("Parent")]
        Parent = 8,

    }
}
