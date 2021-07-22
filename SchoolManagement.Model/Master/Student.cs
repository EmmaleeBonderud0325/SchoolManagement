using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model
{
    public class Student
    {
        public int Id { get; set; }
        public int AdmissionNo { get; set; }
        public string EmegencyContactNo1 { get; set; }
        public string EmegencyContactNo2 { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedById { get; set; }

        public virtual User User { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }


        public virtual ICollection<StudentClass> StudentClasses { get; set; }
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }
        public virtual ICollection<StudentLessonTopicContenet> StudentLessonTopicContenets { get; set; }
        public virtual ICollection<StudentLessonTopic> StudentLessonTopics { get; set; }
    }
}
