using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{

  public class BasicClassViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int AcademicYearId { get; set; }
    public int AcademicLevelId { get; set; }
    public int ClassNameId { get; set; }
    public string ClassTeacherName { get; set; }
    public int TotalStudentCount { get; set; }
  }

  public class ClassViewModel
  {
    public ClassViewModel()
    {
      ClassSubjectTeachers = new List<ClassSubjectTeacherViewModel>();
    }

    public int AcademicYearId { get; set; }
    public int AcademicLevelId { get; set; }
    public int ClassNameId { get; set; }
    public string Name { get; set; }

    public ClassCategory ClassCategoryId { get; set; }
    public LanguageStream LanguageStreamId { get; set; }
    public int ClassTeacherId { get; set; }

    public List<ClassSubjectTeacherViewModel> ClassSubjectTeachers { get; set; }
  }



  public class ClassMasterDataViewModel
  {
    public ClassMasterDataViewModel()
    {

      AcademicYears = new List<DropDownViewModel>();
      AcademicLevels = new List<DropDownViewModel>();
      ClassNames = new List<DropDownViewModel>();
      ClassCategories = new List<DropDownViewModel>();
      LanguageStreams = new List<DropDownViewModel>();
    }


    public int CurrentAcademicYear { get; set; }
    public List<DropDownViewModel> AcademicYears { get; set; }
    public List<DropDownViewModel> AcademicLevels { get; set; }
    public List<DropDownViewModel> ClassNames { get; set; }
    public List<DropDownViewModel> ClassCategories { get; set; }
    public List<DropDownViewModel> LanguageStreams { get; set; }
    public List<DropDownViewModel> AllTeachers { get; set; }
  }
}
