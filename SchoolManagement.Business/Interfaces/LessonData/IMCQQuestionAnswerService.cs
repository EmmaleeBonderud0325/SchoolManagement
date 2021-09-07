using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.LessonData
{
    public interface IMCQQuestionAnswerService
    {
        Task<ResponseViewModel> SaveMCQQuestionAnswer(MCQQuestionAnswerViewModel vm, string userName);
        List<MCQQuestionAnswerViewModel> GetMCQQuestionAnswers();
        List<DropDownViewModel> GetAllQuestion();
    }
}
