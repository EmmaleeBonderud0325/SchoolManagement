using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
  public class SubjectTeachersViewModel
  {
    public SubjectTeachersViewModel()
    {
      AssignedTeacherIds = new List<int>();
      AllTeachers = new List<DropDownViewModel>();
    }
    public int Id { get; set; }
    public int AcademicLevelId { get; set; }
    public int AcademicYearId { get; set; }
    public int SubjectId { get; set; }
    public string Subject { get; set; }
    public string AssignedSubjectTeachersName { get; set; }
    public List<int> AssignedTeacherIds { get; set; }
    public int AssignedTeachersCount { get; set; }

    public List<DropDownViewModel> AllTeachers { get; set; }
  }

  public class SubjectTeacherFilter
  {
    public string SearchText { get; set; }
    public int SelectedAcademicYearId { get; set; }
    public int SelectedAcademicLevelId { get; set; }
  }
}
