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
    public class QuestionService : IQuestionService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public QuestionService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }

        public async Task <ResponseViewModel> SaveQuestion (QuestionViewModel vm, string userName)
        {
            var respone = new ResponseViewModel();
            try 
            {
                var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
                var Questions = schoolDb.Questions.FirstOrDefault(x => x.Id == vm.Id);
                var loggedInUser = currentUserService.GetUserByUsername(userName);

                if (Questions == null) 
                {
                    Questions = new Question()
                    {
                        Id = vm.Id,
                        LessonId = vm.LessonId,
                        TopicId = vm.TopicId,
                        SequnceNo = vm.SequnceNo,
                        QuestionText = vm.QuestionText,
                        Marks = vm.Marks,
                        //DifficultyLevel = vm.DifficultyLevel,
                        //QuestionType = vm.QuestionType,
                        IsActive = vm.IsActive,
                        CreateOn = vm.CreateOn,
                        CreatedById = vm.CreatedById,
                        UpdateOn = vm.UpdateOn,
                        UpdatedById = vm.UpdatedById
                    };

                    schoolDb.Questions.Add(Questions);
                    respone.IsSuccess = true;
                    respone.Message = " Question is Added Successfull.";
                }
                
                else
                {
                    Questions.QuestionText = vm.QuestionText;
                    Questions.Marks = vm.Marks;
                    //Questions.DifficultyLevel = vm.DifficultyLevel;
                    //Questions.QuestionType = vm.QuestionType;
                    Questions.IsActive = vm.IsActive;
                    Questions.CreateOn = vm.CreateOn;
                    Questions.CreatedById = vm.CreatedById;
                    Questions.UpdateOn = vm.UpdateOn;
                    Questions.UpdatedById = vm.UpdatedById;

                    schoolDb.Questions.Update(Questions);
                }

                await schoolDb.SaveChangesAsync();
            }
            
            catch (Exception ex)
            {
                respone.IsSuccess = false;
                respone.Message = ex.ToString();
            }

            return respone;
        }

    }
}
