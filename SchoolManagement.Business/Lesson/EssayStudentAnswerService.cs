
using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class EssayStudentAnswerService : IEssayStudentAnswerService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public EssayStudentAnswerService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }



        public List<EssayStudentAnswerViewModel> GetAllEssayStudentAnswers()
        {
            var response = new List<EssayStudentAnswerViewModel>();

            var query = schoolDb.EssayStudentAnswers.Where(u => u.StudentId != null);

            var EssayStudentAnswerList = query.ToList();

            foreach (var item in EssayStudentAnswerList)
            {
                var vm = new EssayStudentAnswerViewModel
                {

                    QuestionId = item.QuestionId,
                    QuestionName = item.Question.QuestionText,
                    StudentId = item.StudentId,
                    StudentName = item.Student.FullName,
                    EssayQuestionAnswerId = item.EssayQuestionAnswerId,
                    EssayQuestionAnswerName = item.EssayQuestionAnswer.AnswerText,
                    AnswerText = item.AnswerText,
                    TeacherComments = item.TeacherComments,
                    Marks = item.Marks
                };

                response.Add(vm);
            }

            return response;
        }

        public List<DropDownViewModel> GetAllQuestions()
        {
            var questions = schoolDb.Questions
            .Where(x => x.IsActive == true)
            .Select(qe => new DropDownViewModel() { Id = qe.Id, Name = string.Format("{0}", qe.QuestionText) })
            .Distinct().ToList();

            return questions;
        }

        public List<DropDownViewModel> GetAllStudents()
        {
            var students = schoolDb.Students
            .Where(x => x.IsActive == true)
            .Select(st => new DropDownViewModel() { Id = st.Id, Name = string.Format("{0}", st.User.FullName) })
            .Distinct().ToList();

            return students;
        }

        public List<DropDownViewModel> GetAllEssayQuestionAnswers()
        {
            var essayanswers = schoolDb.EssayQuestionAnswers
            .Where(x => x.Question.Id != null)
            .Select(eq => new DropDownViewModel() { Id = eq.Id, Name = string.Format("{0}", eq.AnswerText) })
            .Distinct().ToList();

            return essayanswers;
        }

        public async Task<ResponseViewModel> SaveEssayStudentAnswer(EssayStudentAnswerViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                var EssayStudentAnswers = schoolDb.EssayStudentAnswers.FirstOrDefault(x => x.QuestionId == vm.QuestionId);




                if (EssayStudentAnswers == null)

                {
                    EssayStudentAnswers = new EssayStudentAnswer()
                    {
                        QuestionId = vm.QuestionId,
                        StudentId = vm.StudentId,
                        EssayQuestionAnswerId = vm.EssayQuestionAnswerId,
                        AnswerText = vm.AnswerText,
                        TeacherComments = vm.TeacherComments,
                        Marks = vm.Marks
                    };

                    schoolDb.EssayStudentAnswers.Add(EssayStudentAnswers);

                    response.IsSuccess = true;
                    response.Message = "Essay Student  Answer is Added Successfully";

                }
                else
                {
                    EssayStudentAnswers.TeacherComments = vm.TeacherComments;
                    EssayStudentAnswers.Marks = vm.Marks;


                    schoolDb.EssayStudentAnswers.Update(EssayStudentAnswers);

                    response.IsSuccess = true;
                    response.Message = "Essay Answer is Successfully Updated.";
                }

                await schoolDb.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
            }
            return response;
        }

        public PaginatedItemsViewModel<BasicEssayStudentAnswerViewModel> GetStudentEssayList(string searchText, int currentPage, int pageSize, int questionId, int studentId)
        {
            t     int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vmu = new List<BasicEssayStudentAnswerViewModel>();

            var studentanswers = schoolDb.EssayStudentAnswers.OrderBy(u => u.QuestionId);

            if (!string.IsNullOrEmpty(searchText))
            {
                studentanswers = studentanswers.Where(x => x.Question.QuestionText.Contains(searchText)).OrderBy(u => u.QuestionId);
            }

            if (questionId > 0)
            {
                studentanswers = studentanswers.Where(x => x.QuestionId == questionId).OrderBy(u => u.QuestionId);
            }

            if (studentId > 0)
            {
                studentanswers = studentanswers.Where(x => x.StudentId == studentId).OrderBy(u => u.QuestionId);
            }


            totalRecordCount = studentanswers.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var questionList = studentanswers.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            questionList.ForEach(studentanswers =>
            {
                var vm = new BasicEssayStudentAnswerViewModel()
                {
                    QuestionId = studentanswers.QuestionId,
                    QuestionName = studentanswers.Question.QuestionText,
                    StudentId = studentanswers.StudentId,
                    StudentName = studentanswers.Student.FullName,
                    EssayQuestionAnswerId = studentanswers.EssayQuestionAnswerId,
                    EssayQuestionAnswerName = studentanswers.EssayQuestionAnswer.AnswerText,
                    AnswerText = studentanswers.AnswerText,
                    TeacherComments = studentanswers.TeacherComments,
                    Marks = studentanswers.Marks


                };
                vmu.Add(vm);
            });

            var container = new PaginatedItemsViewModel<BasicEssayStudentAnswerViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

            return container;
        }
    }
}

