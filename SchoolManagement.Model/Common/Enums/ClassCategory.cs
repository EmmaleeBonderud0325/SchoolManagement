using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
	public enum ClassCategory
    {
        [Description("O/Level")]
        Primary = 1,
        [Description("O/Level")]
        Secondary = 2,
        [Description("O/Level")]
        OLevel = 3,
        [Description("A/Level-Maths")]
        ALevelMaths = 4,
        [Description("A/Level-Bio")]
        ALevelBio = 5,
        [Description("A/Level-Technology")]
        ALevelTechnology = 6,
        [Description("A/Level-Commerce")]
        ALevelCommerce = 7
    };
}
