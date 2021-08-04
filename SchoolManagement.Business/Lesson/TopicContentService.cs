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
    public class TopicContentService : ITopicContentService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public TopicContentService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }
        //public List<TopicContentViewModel> GetAllTopicContent()
        //{
        //    var response = new List<TopicContentViewModel>();
        //    var query = schoolDb.Lessons.Where(u => u.Id == 123);
        //    var LessonList = query.ToList();

        //    foreach (var TopicContent in LessonList)
        //    {
        //        var vm = new TopicContentViewModel
        //        {
        //            Id = TopicContent.Id,
        //            TopicId = TopicContent.TopicId,
        //            Introduction = TopicContent.Introduction,
        //            Content = TopicContent.Content,
        //            CreatedOn = TopicContent.CreatedOn,
        //            UpdatedOn = TopicContent.UpdatedOn
        //        };
        //        response.Add(vm);
        //    }
        //    return response;

        //}
        //public async Task<ResponseViewModel> SaveTopicContent(LessonViewModel vm, string userName)
        //{
        //    var response = new ResponseViewModel();
        //    try
        //    {
        //        var currentuser = schoolDb.Users.FirstOrDefault(x => x.Username.ToUpper() == userName.ToUpper());
        //        var MCQQuestionAnswers = schoolDb.MCQQuestionAnswers.FirstOrDefault(x => x.Id == vm.Id);
        //        var loggedInUser = currentUserService.GetUserByUsername(userName);

        //        if (TopicContent == null)
        //        {
        //            TopicContent = new TopicContent()
        //            {
        //                Id = vm.Id,
        //                TopicId = vm.TopicId,
        //                Introduction = vm.Introduction,
        //                Content = vm.Content,
        //                CreatedOn = vm.CreatedOn,
        //                UpdatedOn = vm.UpdatedOn
        //            };
        //            schoolDb.TopicContents.Add(TopicContent);
        //            response.IsSuccess = true;
        //            response.Message = " Topic Content is added successfully";
        //        }
        //        else
        //        {

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    } 
}
