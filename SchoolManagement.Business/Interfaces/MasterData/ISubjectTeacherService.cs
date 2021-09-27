using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
  public interface ISubjectTeacherService
  {
    List<SubjectTeachersViewModel> GetAllSubjectTeachers(SubjectTeacherFilter filter);
    Task<ResponseViewModel> SaveSubjectTeacher(SubjectTeachersViewModel vm, string userName);
    SubjectTeacherMasterDataViewModel GetSubjectTeacherMasterData();
    List<DropDownViewModel> GetSubjectsForSelectedAcademicLevel(int academicLevelId);
  }
}
