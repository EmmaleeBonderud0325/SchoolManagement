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
    public class MCQQuestionStudentAnswerService : IMCQQuestionStudentAnswerService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public MCQQuestionStudentAnswerService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public List<MCQQuestionStudetAnswerViewModel> GetAllMCQQuestionStudentAnswers()
        {
            var response = new List<MCQQuestionStudetAnswerViewModel>();
            var query = schoolDb.MCQQuestionStudentAnswers.Where(u => u.IsChecked == true);
            var MCQQuestionStudentAnswerList = query.ToList();

            foreach (var MCQQuestionStudentAnswer in MCQQuestionStudentAnswerList)
            {
                var vm = new MCQQuestionStudetAnswerViewModel
                {
                    QuestionId = MCQQuestionStudentAnswer.QuestionId,
                    StudentId = MCQQuestionStudentAnswer.StudentId,
                    MCQQuestionAnswerId = MCQQuestionStudentAnswer.MCQQuestionAnswerId,
                    AnswerText = MCQQuestionStudentAnswer.AnswerText,
                    SequnceNo = MCQQuestionStudentAnswer.SequnceNo,
                    IsChecked = MCQQuestionStudentAnswer.IsChecked
                };
                response.Add(vm);
            }
            return response;
        }

        public async Task <ResponseViewModel> SaveMCQQuestionStudentAnswer (MCQQuestionStudetAnswerViewModel vm, string userName)
        {
            var responce = new ResponseViewModel();
            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
                var MCQQuestionStudentAnswers = schoolDb.MCQQuestionStudentAnswers.FirstOrDefault(x => x.QuestionId == vm.QuestionId);
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                if (MCQQuestionStudentAnswers == null)
                {
                    MCQQuestionStudentAnswers = new MCQQuestionStudentAnswer()
                    {
                        //QuestionId = vm.QuestionId,
                        //StudentId = vm.StudentId,
                        //MCQQuestionAnswerId = vm.MCQQuestionAnswerId,
                        AnswerText = vm.AnswerText,
                        SequnceNo = vm.SequnceNo,
                        IsChecked = vm.IsChecked
                    };

                    schoolDb.MCQQuestionStudentAnswers.Add(MCQQuestionStudentAnswers);
                    responce.IsSuccess = true;
                    responce.Message = " MCQ Question Student Answers are added successfully";

                }

                else
                {
                    MCQQuestionStudentAnswers.AnswerText = vm.AnswerText;
                    MCQQuestionStudentAnswers.SequnceNo = vm.SequnceNo;
                    MCQQuestionStudentAnswers.IsChecked = vm.IsChecked;

                    schoolDb.MCQQuestionStudentAnswers.Update(MCQQuestionStudentAnswers);
                }

                await schoolDb.SaveChangesAsync();
            }
            
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.ToString();
            }

            return responce;
        }
    }
}
