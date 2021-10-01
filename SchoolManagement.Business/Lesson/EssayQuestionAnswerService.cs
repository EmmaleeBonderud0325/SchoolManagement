
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
    public class EssayQuestionAnswerService : IEssayQuestionAnswerService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public EssayQuestionAnswerService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }
        //Get All EssayQuestionAnswers
        public List<EssayQuestionAnswerViewModel> GetAllEssayQuestionAnswers()
        { 
            var response = new List<EssayQuestionAnswerViewModel>();
            //var query = schoolDb.EssayQuestionAnswers(questions, q => q.Id, e => e.QuestionId, (q, e) => new { question = q, essaquestionaswers = e };
            var query =schoolDb.EssayQuestionAnswers.Where(u => u.QuestionId != null);
            //var query = from question in schoolDb.Questions
                      //  join essayanswers in schoolDb.EssayQuestionAnswers on question.Id equals essayanswers.QuestionId
                       // select new { Id = essayanswers.Id, QuestionId = essayanswers.Id, AnswerText = essayanswers.AnswerText, ModifiedOn = essayanswers.ModifiedOn, CreatedOn = essayanswers.CreatedOn }
                    //    ;
             

            var EssayQuestionAnswerList = query.ToList();

            foreach (var item in EssayQuestionAnswerList)
            {
                var vm = new EssayQuestionAnswerViewModel
                {

                    Id = item.Id,
                    QuestionId = item.QuestionId,
                    QuestionName = item.Question.QuestionText,
                    AnswerText = item.AnswerText,
                    ModifiedOn = DateTime.UtcNow,
                    CreatedOn = DateTime.UtcNow
                };

                response.Add(vm);
            }

            return response;
        }


        //Save
        public async Task<ResponseViewModel> SaveEssayQuestionAnswer(EssayQuestionAnswerViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

                var EssayQuestionAnswers = schoolDb.EssayQuestionAnswers.FirstOrDefault(x => x.Id == vm.Id);

                var loggedInUser = currentUserService.GetUserByUsername(userName);

                if (EssayQuestionAnswers == null)
                {
                    EssayQuestionAnswers = new EssayQuestionAnswer()
                    {
                        Id = vm.Id,
                        QuestionId = vm.QuestionId,
                        AnswerText = vm.AnswerText,
                        ModifiedOn = DateTime.UtcNow,
                        CreatedOn = DateTime.UtcNow
                    };

                    schoolDb.EssayQuestionAnswers.Add(EssayQuestionAnswers);

                    response.IsSuccess = true;
                    response.Message = "Essay Answer is Added Successfully";
                }

                else
                {
                    EssayQuestionAnswers.AnswerText = vm.AnswerText;
                    EssayQuestionAnswers.ModifiedOn = DateTime.UtcNow;

                    schoolDb.EssayQuestionAnswers.Update(EssayQuestionAnswers);

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

        //Delete
        public async Task<ResponseViewModel> DeleteEssayAnswer(int essayAnswerid)
        {
            var response = new ResponseViewModel();

            try
            {
                var essayanswers = schoolDb.EssayQuestionAnswers.FirstOrDefault(x => x.Id == essayAnswerid);

                schoolDb.EssayQuestionAnswers.Update(essayanswers);
                await schoolDb.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Essay Answer is successfully deleted.";
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
           .Select(qe => new DropDownViewModel() { Id = qe.Id, Name = string.Format("{0}", qe.QuestionText) })
           .Distinct().ToList();

            return questions;
        }
        //question list 
        public PaginatedItemsViewModel<BasicEssayQuestionAnswerViewModel> GetQuestionList(string searchText, int currentPage, int pageSize, int questionId)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;

            var vmu = new List<BasicEssayQuestionAnswerViewModel>();

            var essayquestions = schoolDb.EssayQuestionAnswers.OrderBy(u => u.Id);

            if (!string.IsNullOrEmpty(searchText))
            {
                essayquestions = essayquestions.Where(x => x.Question.QuestionText.Contains(searchText)).OrderBy(u => u.Id);
            }

            if (questionId > 0)
            {
                essayquestions = essayquestions.Where(x => x.QuestionId == questionId).OrderBy(u => u.Id);
            }


            totalRecordCount = essayquestions.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var questionList = essayquestions.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            questionList.ForEach(essayquestions =>
            {
                var vm = new BasicEssayQuestionAnswerViewModel()
                {
                    Id = essayquestions.Id,
                    QuestionId = essayquestions.QuestionId,
                    QuestionName = essayquestions.Question.QuestionText,
                    AnswerText = essayquestions.AnswerText,
                    ModifiedOn = DateTime.UtcNow,
                    CreatedOn = DateTime.UtcNow


                };
                vmu.Add(vm);
            });

            var container = new PaginatedItemsViewModel<BasicEssayQuestionAnswerViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vmu);

            return container;
        }
    }
}
