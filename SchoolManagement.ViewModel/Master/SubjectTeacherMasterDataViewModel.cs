using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
  public class SubjectTeacherMasterDataViewModel
  {
    public SubjectTeacherMasterDataViewModel()
    {
      AcademicYears = new List<DropDownViewModel>();
      AcademicLevels = new List<DropDownViewModel>();
    }

    public int CurrentAcademicYear { get; set; }
    public List<DropDownViewModel> AcademicYears { get; set; }
    public List<DropDownViewModel> AcademicLevels { get; set; }
  }
}
