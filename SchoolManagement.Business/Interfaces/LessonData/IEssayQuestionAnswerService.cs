using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.LessonData
{
    public interface IEssayQuestionAnswerService
    {
        Task<ResponseViewModel> SaveEssayQuestionAnswer(EssayQuestionAnswerViewModel vm, string userName);
    }
}
