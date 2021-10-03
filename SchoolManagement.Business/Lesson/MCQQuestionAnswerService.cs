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
    public class MCQQuestionAnswerService : IMCQQuestionAnswerService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public MCQQuestionAnswerService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<MCQQuestionAnswerViewModel> GetMCQQuestionAnswers()
        {
            var response = new List<MCQQuestionAnswerViewModel>();
            var query = schoolDb.MCQQuestionAnswers.Where(u => u.Id != 0);
            var MCQQuestionAnswerList = query.ToList();

            foreach (var item in MCQQuestionAnswerList)
            {
                var vm = new MCQQuestionAnswerViewModel
                {
                    Id = item.Id,
                    QuestionId = item.QuestionId,
                    QuestionName = item.Question.QuestionText,
                    AnswerText = item.AnswerText,
                    SequenceNo = item.SequenceNo,
                    IsCorrectAnswer = item.IsCorrectAnswer,
                    ModifiedDate = DateTime.UtcNow,
                    CreatedOn = DateTime.UtcNow
                };
                response.Add(vm);
            }
            return response;
        }

        public async Task<ResponseViewModel> SaveMCQQuestionAnswer(MCQQuestionAnswerViewModel vm, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                //var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
                var MCQQuestionAnswers = schoolDb.MCQQuestionAnswers.FirstOrDefault(x => x.Id == vm.Id);
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                if(MCQQuestionAnswers == null)
                {
                    MCQQuestionAnswers = new MCQQuestionAnswer()
                    {
                        Id = vm.Id,
                        QuestionId = vm.QuestionId,
                        AnswerText = vm.AnswerText,
                        //SequenceNo = vm.SequenceNo,
                        IsCorrectAnswer = vm.IsCorrectAnswer,
                        ModifiedDate = DateTime.UtcNow,
                        CreatedOn = DateTime.UtcNow
                    };

                    schoolDb.MCQQuestionAnswers.Add(MCQQuestionAnswers);
                    response.IsSuccess = true;
                    response.Message = " MCQ Question Answer is added successfull.";
                }

                else
                {
                    MCQQuestionAnswers.AnswerText = vm.AnswerText;
                    //MCQQuestionAnswers.SequenceNo = vm.SequenceNo;
                    MCQQuestionAnswers.IsCorrectAnswer = vm.IsCorrectAnswer;
                    MCQQuestionAnswers.ModifiedDate = vm.ModifiedDate;
                    //MCQQuestionAnswers.CreatedOn = vm.CreatedOn;

                    schoolDb.MCQQuestionAnswers.Update(MCQQuestionAnswers);
                    response.IsSuccess = true;
                    response.Message = " MCQ Question Answer is Updated successfull.";
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

        public List<DropDownViewModel> GetAllQuestions()
        {
            var questions = schoolDb.Questions
            .Where(x => x.IsActive == true)
            .Select(qu => new DropDownViewModel() { Id = qu.Id, Name = string.Format("{0}", qu.QuestionText) })
            .Distinct().ToList();

            return questions;
        }

        public PaginatedItemsViewModel<BasicMCQQuestionAnswerViewModel> GetQuestionList(string searchText, int currentPage, int pageSize, int questionId)
        {
                int totalRecordCount = 0;
                double totalPages = 0;
                int totalPageCount = 0;

                var vmu = new List<BasicMCQQuestionAnswerViewModel>();

                var question = schoolDb.MCQQuestionAnswers.OrderBy(x => x.QuestionId);

                if (!string.IsNullOrEmpty(searchText))
                {
                    question = question.Where(x => x.Question.QuestionText.Contains(searchText)).OrderBy(x => x.QuestionId);
                }

                if (questionId > 0)
                {
                    question = question.Where(x => x.QuestionId == questionId).OrderBy(x => x.QuestionId);
                }


                totalRecordCount = question.Count();
                totalPages = (double)totalRecordCount / pageSize;
                totalPageCount = (int)Math.Ceiling(totalPages);

                var questionList = question.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            questionList.ForEach(question =>
                {
                    var vm = new BasicMCQQuestionAnswerViewModel()
                    {
                        Id = question.Id,
                        QuestionId = question.QuestionId,
                        QuestionName = question.Question.QuestionText,
                        AnswerText = question.AnswerText,
                        SequenceNo = question.SequenceNo,
                        ModifiedDate = DateTime.UtcNow,
                        CreatedOn = DateTime.UtcNow

                    };
                    vmu.Add(vm);
                });

                var container = new PaginatedItemsViewModel<BasicMCQQuestionAnswerViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

                return container;
            }
        
    }
}
