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

        public MCQQuestionAnswerService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public async Task<ResponseViewModel> SaveMCQQuestionAnswer(MCQQuestionAnswerViewModel vm, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
                var MCQQuestionAnswers = schoolDb.MCQQuestionAnswers.FirstOrDefault(x => x.Id == vm.Id);

                if(MCQQuestionAnswers == null)
                {
                    MCQQuestionAnswers = new MCQQuestionAnswer()
                    {
                        Id = vm.Id,
                        QuestionId = vm.QuestionId,
                        AnswerText = vm.AnswerText,
                        SequenceNo = vm.SequenceNo,
                        IsCorrectAnswer = vm.IsCorrectAnswer,
                        ModifiedDate = vm.ModifiedDate,
                        CreatedOn = vm.CreatedOn
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
