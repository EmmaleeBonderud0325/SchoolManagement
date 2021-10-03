using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.LessonData
{
    public interface IQuestionService
    {
        Task<ResponseViewModel> SaveQuestion(QuestionViewModel vm, string userName);
        List<QuestionViewModel> GetAllQuestions();
        Task<ResponseViewModel> DeleteQuestion(int Id);
        List<DropDownViewModel> GetAllLessonName();
        List<DropDownViewModel> GetAllTopic();

        PaginatedItemsViewModel<BasicQuestionViewModel> GetLessonList(string searchText, int currentPage, int pageSize, int LessonId);


    }
}
