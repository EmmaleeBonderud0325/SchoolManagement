using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Lesson
{
    public class LessonAssignmentViewModel
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string  LessonName{ get; set; }
        public string Name { get; set; }
        public string Descripstion { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedByName { get; set; }
    }
}
