using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.LessonData
{
    public interface ILessonAssignmentService
    {
        Task<ResponseViewModel> SaveLessonAssignment(LessonAssignmentViewModel vm, string userName);

        List<LessonAssignmentViewModel> GetLessonAssignments();

        Task<ResponseViewModel> DeleteLessonAssignment(int Id);

        List<DropDownViewModel> GetAllLessons();

        PaginatedItemsViewModel<BasicLessonAssignmentViewModel> GetLessonList(string searchText, int currentPage, int pageSize, int lessonId);
    }
}
