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
    public class EssayQuestionAnswerService : IEssayQuestionAnswerService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;

        public EssayQuestionAnswerService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public async Task<ResponseViewModel> SaveEssayQuestionAnswer(EssayQuestionAnswerViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

                var EssayQuestionAnswers = schoolDb.EssayQuestionAnswers.FirstOrDefault(x => x.Id == vm.Id);

                if (EssayQuestionAnswers == null)
                {
                    EssayQuestionAnswers = new EssayQuestionAnswer()
                    {
                        Id = vm.Id,
                        QuestionId = vm.QuestionId,
                        AnswerText = vm.AnswerText,
                        ModifiedOn = vm.ModifiedOn,
                        CreatedOn = vm.CreatedOn
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
