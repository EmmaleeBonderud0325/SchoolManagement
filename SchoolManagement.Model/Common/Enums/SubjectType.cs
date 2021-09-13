using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Common.Enums
{
    public enum SubjectType
    {
        [Description("Normal Subject")]
        NormalSubject = 1,
        [Description("Parent Basket Subject")]
        ParentBasketSubject = 2,
        [Description("Basket Subject")]
        BasketSubject = 3,
    }
}
