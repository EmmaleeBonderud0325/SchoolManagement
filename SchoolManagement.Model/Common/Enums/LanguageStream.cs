using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
  public enum LanguageStream
  {
    [Description("Sinhala")]
    Sinhala = 1,
    [Description("English")]
    English = 2,
    [Description("Tamil")]
    Tamil = 3,
    [Description("Other")]
    Other = 4
  };
}
