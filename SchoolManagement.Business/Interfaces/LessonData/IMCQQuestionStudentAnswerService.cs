using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.LessonData
{
    public interface IMCQQuestionStudentAnswerService
    {
        Task<ResponseViewModel> SaveMCQQuestionStudentAnswer(MCQQuestionStudetAnswerViewModel vm, string userName);
        List<MCQQuestionStudetAnswerViewModel> GetAllMCQQuestionStudentAnswers();
        List<DropDownViewModel> GetAllQuestion();
        List<DropDownViewModel> GetAllStudentName();
        List<DropDownViewModel> GetAllTeacherAnswer();

        PaginatedItemsViewModel<BasicMCQQuestionStudentAnswerViewModel> GetStudentList(string searchText, int currentPage, int pageSize, int studentId, int questionId);
    }
}
