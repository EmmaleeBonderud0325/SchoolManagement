using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class LessonViewModel
    {
        public LessonViewModel()
        {
            Topics = new List<TopicViewModel>();
            LessonDetail = new LessonDetailViewModel();
        }
        public int Id { get; set; }
        public LessonDetailViewModel LessonDetail { get; set; }
        public List<TopicViewModel> Topics { get; set; }

    }

    public class LessonDetailViewModel
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public LessonStatus Status { get; set; }
        public string Description { get; set; }

        public int AcademicLevelId { get; set; }
        public int ClassNameId { get; set; }
        public int AcademicYearId { get; set; }
        public int SubjectId { get; set; }

        public string LearningOutcome { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
