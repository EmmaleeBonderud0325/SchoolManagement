using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.LessonData
{
    public interface ILessonDesignService
    {
        Task<ResponseViewModel> SaveLesson(LessonViewModel vm, string userName);
        List<LessonViewModel> GetAllLessons();
        Task<ResponseViewModel> SaveTopic(TopicViewModel vm, string userName);
    }
}
