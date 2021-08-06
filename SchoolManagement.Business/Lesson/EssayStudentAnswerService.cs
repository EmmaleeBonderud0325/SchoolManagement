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

            var query = schoolDb.EssayStudentAnswers.Where(u => u.StudentId == 123);

            var EssayStudentAnswerList = query.ToList();

            foreach (var essaystudentanswer in EssayStudentAnswerList)
            {
                var vm = new EssayStudentAnswerViewModel
                {
 
                    QuestionId = essaystudentanswer.QuestionId,
                    StudentId = essaystudentanswer.StudentId,
                    EssayQuestionAnswerId = essaystudentanswer.EssayQuestionAnswerId,
                    AnswerText = essaystudentanswer.AnswerText,
                    TeacherComments = essaystudentanswer.TeacherComments,
                    Marks = essaystudentanswer.Marks
                };

                response.Add(vm);
            }

            return response;
        }

            public async Task<ResponseViewModel> SaveEssayStudentAnswer(EssayStudentAnswerViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());

                var EssayStudentAnswers = schoolDb.EssayStudentAnswers.FirstOrDefault(x => x.QuestionId == vm.QuestionId);

                var loggedInUser = currentUserService.GetUserByUsername(userName);


                if (EssayStudentAnswers == null)
                    
                {
                    EssayStudentAnswers = new EssayStudentAnswer()
                    {
                        QuestionId = vm.QuestionId,
                        StudentId = vm.StudentId,
                        //EssayQuestionAnswerId = vm.EssayQuestionAnswerId,
                        //AnswerText = vm.AnswerText,
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

