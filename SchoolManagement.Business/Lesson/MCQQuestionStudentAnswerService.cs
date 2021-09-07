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

            foreach (var item in MCQQuestionStudentAnswerList)
            {
                var vm = new MCQQuestionStudetAnswerViewModel
                {
                    QuestionId = item.QuestionId,
                    QuestionName = item.MCQQuestionAnswer.Question.QuestionText,
                    StudentId = item.StudentId,
                    StudentName = item.StudentMCQQuestion.Student.User.FullName,
                    MCQQuestionAnswerId = item.MCQQuestionAnswerId,
                    MCQQuestionAnswerName = item.MCQQuestionAnswer.AnswerText,
                    AnswerText = item.AnswerText,
                    SequnceNo = item.SequnceNo,
                    IsChecked = item.IsChecked
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





        public List<DropDownViewModel> GetAllQuestion()
        {
            var question = schoolDb.Questions
            .Where(x => x.IsActive == true)
            .Select(q => new DropDownViewModel() { Id = q.Id, Name = string.Format("{0}", q.QuestionText) })
            .Distinct().ToList();

            return question;
        }

        public List<DropDownViewModel> GetAllStudentName()
        {
            var student = schoolDb.Students
            .Where(x => x.IsActive == true)
            .Select(s => new DropDownViewModel() { Id = s.Id, Name = string.Format("{0}", s.Id) })
            .Distinct().ToList();

            return student;
        }

        public List<DropDownViewModel> GetAllTeacherAnswer()
        {
            var teacher = schoolDb.MCQQuestionAnswers
             .Where(x => x.QuestionId != null)
             .Select(t => new DropDownViewModel() { Id = t.Id, Name = string.Format("{0}", t) })
             .Distinct().ToList();

            return teacher;
        }
    }
}
