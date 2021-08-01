using Castle.Core.Configuration;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Lesson
{
    public class StudentMCQQuestionService : IStudentMCQQuestionService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public StudentMCQQuestionService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public async Task<ResponseViewModel> SaveStudentMCQQuestion(StudentMCQQuestionViewModel vm, string userName)
        {
            var respone = new ResponseViewModel();
            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
                var StudentMCQQuestions = schoolDb.StudentMCQQuestions.FirstOrDefault(x => x.QuestionId == vm.QuestionId);

                if (StudentMCQQuestions == null)
                {
                    StudentMCQQuestions = new StudentMCQQuestion()
                    {
                        QuestionId = vm.QuestionId,
                        StudentId = vm.StudentId,
                        TeacherComments = vm.TeacherComments,
                        Marks = vm.Marks,
                        IsCorrectAnswer = vm.IsCorrectAnswer
                    };

                    schoolDb.StudentMCQQuestions.Add(StudentMCQQuestions);
                    respone.IsSuccess = true;
                    respone.Message = " Student MCQ Question is added susccesfully.";
                }

                else
                {
                    StudentMCQQuestions.TeacherComments = vm.TeacherComments;
                    StudentMCQQuestions.Marks = vm.Marks;
                    StudentMCQQuestions.IsCorrectAnswer = vm.IsCorrectAnswer;

                    schoolDb.StudentMCQQuestions.Update(StudentMCQQuestions);
                }

                await schoolDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                respone.IsSuccess = false;
                respone.Message = ex.ToString();
            }

            return respone;
        }
    }
}
