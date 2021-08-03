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

        public List<MCQQuestionAnswerViewModel> GetAllMCQQuestionAnswer()
        {
            var response = new List<MCQQuestionAnswerViewModel>();
            var query = schoolDb.MCQQuestionAnswers.Where(u => u.IsCorrectAnswer == true);
            var MCQQuestionAnswerList = query.ToList();

            foreach (var MCQQuestionAnswer in MCQQuestionAnswerList)
            {
                var vm = new MCQQuestionAnswerViewModel
                {
                    Id = MCQQuestionAnswer.Id,
                    QuestionId = MCQQuestionAnswer.QuestionId,
                    AnswerText = MCQQuestionAnswer.AnswerText,
                    SequenceNo = MCQQuestionAnswer.SequenceNo,
                    IsCorrectAnswer = MCQQuestionAnswer.IsCorrectAnswer,
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
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
                var MCQQuestionAnswers = schoolDb.MCQQuestionAnswers.FirstOrDefault(x => x.Id == vm.Id);
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                if(MCQQuestionAnswers == null)
                {
                    MCQQuestionAnswers = new MCQQuestionAnswer()
                    {
                        Id = vm.Id,
                        QuestionId = vm.QuestionId,
                        AnswerText = vm.AnswerText,
                        SequenceNo = vm.SequenceNo,
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
                    MCQQuestionAnswers.SequenceNo = vm.SequenceNo;
                    MCQQuestionAnswers.IsCorrectAnswer = vm.IsCorrectAnswer;
                    MCQQuestionAnswers.ModifiedDate = vm.ModifiedDate;
                    MCQQuestionAnswers.CreatedOn = vm.CreatedOn;

                    schoolDb.MCQQuestionAnswers.Update(MCQQuestionAnswers);
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
