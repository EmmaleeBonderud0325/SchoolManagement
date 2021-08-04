using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
     public  class LessonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VersionNo { get; set; }
        public string LearningOutcome { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedById { get; set; }
        public string Introduction { get; set; }
        public int TopicId { get; set; }
        public string Content { get; set; }

        public DropDownViewModel SelectedOwner { get; set; }
        public DropDownViewModel SelectedAcademicLevel { get; set; }
        public DropDownViewModel SelectedClassName { get; set; }
        public DropDownViewModel SelectedAcademicYear { get; set; }
        public DropDownViewModel SelectedSubject { get; set; }

        //public List<QuestionViewModel> TeacherEssyQuestions { get; set; }
        //public List<QuestionViewModel> TeacherMCQQuestions { get; set; }
        //public List<StudentMCQQuestionViewModel> StudentEssyQuestion { get; set; }
    }
}
