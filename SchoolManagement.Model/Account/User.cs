using SchoolManagement.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Account
{
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public byte ProfileImage { get; set; }
        public string Address { get; set; }
        public int LoginSessionId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? UpdatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual Student Student { get; set; }


        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<User> CreatedUsers { get; set; }
        public virtual ICollection<User> UpdatedUsers { get; set; }
        public virtual ICollection<UserRole> CreatedUserRoles { get; set; }
        public virtual ICollection<UserRole> UpdatedUserRoles { get; set; }

        //Navigation Property Academic
        public virtual ICollection<AcademicLevel> LevelHeads { get; set; }
        public virtual ICollection<AcademicLevel> CreatedAcademicLevels { get; set; }
        public virtual ICollection<AcademicLevel> UpdatedAcademicLevels { get; set; }

        public virtual ICollection<AcademicYear> CreatedAcademicYears { get; set; }
        public virtual ICollection<AcademicYear> UpdatedAcademicYears { get; set; }
        
        //Navigation Property Class
        public virtual ICollection<ClassName> CreatedClassNames { get; set; }
        public virtual ICollection<ClassName> UpdatedClassNames { get; set; }

        public virtual ICollection<Class> UpdatedClasses { get; set; }
        public virtual ICollection<Class> CreatedClasses { get; set; }

        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<ClassTeacher> CreatedClassTeachers { get; set; }
        public virtual ICollection<ClassTeacher> UpdatedClassTeachers { get; set; }
        //Navigation property Subject
        public virtual ICollection<Subject> CreatedSubjects { get; set; }
        public virtual ICollection<Subject> UpdatedSubjects { get; set; }

        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual ICollection<SubjectTeacher> CreatedSubjectTeachers { get; set; }
        public virtual ICollection<SubjectTeacher> UpdatedSubjectTeachers { get; set; }

        public virtual ICollection<ClassSubjectTeacher> CreatedClassSubjectTeachers { get; set; }
        public virtual ICollection<ClassSubjectTeacher> UpdatedClassSubjectTeachers { get; set; }

        //Navigation property Question
        public virtual ICollection<StudentMCQQuestion> StudentMCQQuestions { get; set; }
        public virtual ICollection<MCQStudentAnswer> MCQStudentAnswers { get; set; }

        //Navigatation property Lesson assignment
        public virtual ICollection<LessonAssignment> CreatedLessonAssignments { get; set; }
        public virtual ICollection<LessonAssignment> UpdatedLessonAssignments { get; set; }

        public virtual ICollection<LessonAssignmentSubmission> LessonAssignmentSubmissions { get; set; }

        //Navigation property Student
        public virtual ICollection<Student> CreatedStudents { get; set; }
        public virtual ICollection<Student> UpdatedStudents { get; set; }

       

        //Navigation property Lesson
        public virtual ICollection<Lesson> CreatedLessons { get; set; }
        public virtual ICollection<Lesson> UpdatedLessons { get; set; }

        public virtual ICollection<Lesson> OwnerLessons { get; set; }

        //Navigation property EssayStudentAnswer
        public virtual ICollection<EssayStudentAnswer> EssayStudentAnswers { get; set; }

        //Navigation property SubjectStream
        public virtual ICollection<SubjectStream> CreatedSubjectStreams { get; set; }
        public virtual ICollection<SubjectStream> UpdatedSubjectStreams { get; set; }

        //Navigation property HeadOfDepartment

        public virtual ICollection<HeadOfDepartment> CreatedHeadOfDepartments { get; set; }
        public virtual ICollection<HeadOfDepartment> UpdatedHeadOfDepartments { get; set; }




    }
}
