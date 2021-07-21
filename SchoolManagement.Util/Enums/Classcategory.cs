using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util.Enums
{
	public enum ClassCategory
    {
        [Description("O/Level")]
        OLevel = 1,
        [Description("A/Level-Maths")]
        ALevelMaths = 2,
        [Description("A/Level-Bio")]
        ALevelBio = 3,
        [Description("A/Level-Technology")]
        ALevelTechnology = 4,
        [Description("A/Level-Commerce")]
        ALevelCommerce = 5
    };
}
