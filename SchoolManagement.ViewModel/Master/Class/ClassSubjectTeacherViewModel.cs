using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
  public class ClassSubjectTeacherViewModel
  {
    public ClassSubjectTeacherViewModel()
    {
      AllSubjectTeachers = new List<DropDownViewModel>();
    }
    public int Id { get; set; }
    public int ClassNameId { get; set; }
    public int AcademicLevelId { get; set; }
    public int AcademicYearId { get; set; }
    public int SubjectId { get; set; }
    public int SubjectTeacherId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }


    public string SubjectName { get; set; }
    public List<DropDownViewModel> AllSubjectTeachers { get; set; }

  }
}
