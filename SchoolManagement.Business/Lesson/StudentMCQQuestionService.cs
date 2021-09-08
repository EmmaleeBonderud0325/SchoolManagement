using Microsoft.Extensions.Configuration;
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

namespace SchoolManagement.Business
{
    public class StudentMCQQuestionService : IStudentMCQQuestionService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public StudentMCQQuestionService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }


        public List<StudentMCQQuestionViewModel> GetAllStudentMCQQuestions()
        {
            var response = new List<StudentMCQQuestionViewModel>();
            var query = schoolDb.StudentMCQQuestions.Where(u => u.Question.Id != null);
            var StudentMCQQuestionList = query.ToList();

            foreach (var item in StudentMCQQuestionList) 
            {
                var vm = new StudentMCQQuestionViewModel
                {
                    QuestionId = item.QuestionId,
                    QuestionName = item.Question.QuestionText,
                    StudentId = item.StudentId,
                    StudentName = item.Student.User.FullName,
                    TeacherComments = item.TeacherComments,
                    Marks = item.Marks,
                    IsCorrectAnswer = item.IsCorrectAnswer
                };
                response.Add(vm);
            }
            return response;
        }

        public async Task<ResponseViewModel> SaveStudentMCQQuestion(StudentMCQQuestionViewModel vm, string userName)
        {
            var respone = new ResponseViewModel();
            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
                var StudentMCQQuestions = schoolDb.StudentMCQQuestions.FirstOrDefault(x => x.QuestionId == vm.QuestionId);
                var loggedInUser = currentUserService.GetUserByUsername(userName);

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
                    respone.IsSuccess = true;
                    respone.Message = " Student MCQ Question is updated susccesfully.";
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

        public List<DropDownViewModel> GetAllQuestions()
        {
            var questions = schoolDb.Questions
              .Where(x => x.IsActive == true)
              .Select(q => new DropDownViewModel() { Id = q.Id, Name = string.Format("{0}", q.QuestionText) })
              .Distinct().ToList();

            return questions;
        }

        public List<DropDownViewModel> GetAllStudentNames()
        {
            var students = schoolDb.Students
              .Where(x => x.IsActive == true)
              .Select(s => new DropDownViewModel() { Id = s.Id, Name = string.Format("{0}", s.User.FullName) })
              .Distinct().ToList();

            return students;
        }
    }
}
