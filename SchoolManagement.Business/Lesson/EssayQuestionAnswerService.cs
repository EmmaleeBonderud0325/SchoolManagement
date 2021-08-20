
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

            foreach (var essayquestionanswer in EssayQuestionAnswerList)
            {
                var vm = new EssayQuestionAnswerViewModel
                {

                    Id = essayquestionanswer.Id,
                    QuestionId = essayquestionanswer.QuestionId,
                    AnswerText = essayquestionanswer.AnswerText,
                    ModifiedOn = essayquestionanswer.ModifiedOn,
                    CreatedOn = essayquestionanswer.CreatedOn
                };

                response.Add(vm);
            }

            return response;
        }

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
                    EssayQuestionAnswers.ModifiedOn = vm.ModifiedOn;
                    EssayQuestionAnswers.CreatedOn = vm.CreatedOn;

                    schoolDb.EssayQuestionAnswers.Update(EssayQuestionAnswers);
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

    }
}
