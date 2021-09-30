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
    public interface ILessonDesignService
    {
        Task<ResponseViewModel> SaveLesson(LessonViewModel vm, string userName);
        List<LessonViewModel> GetAllLessons(LessonFilterViewModel filters, string userName);
        Task<ResponseViewModel> SaveTopic(TopicViewModel vm, string userName);
        Task<ResponseViewModel> DeleteLesson(int id);
        LessonMasterDataViewModel GetLessonMasterData();
        PaginatedItemsViewModel<BasicLessonViewModel> GetLessonList(string searchText, int academicYearId, int academicLevelId,
                                                                     int currentPage, int classNameId, int subjectId, int pageSize, string userName);

        LessonViewModel GetLessonById(int id);
    }

}
