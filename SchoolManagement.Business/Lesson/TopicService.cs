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
    public class TopicService : ITopicService
    {
        private readonly MasterDbContext masterDb;
        private readonly SchoolManagementContext schoolDb;
        private readonly IConfiguration config;
        private readonly ICurrentUserService currentUserService;

        public TopicService(MasterDbContext masterDb, SchoolManagementContext schoolDb, IConfiguration config, ICurrentUserService currentUserService)
        {
            this.masterDb = masterDb;
            this.schoolDb = schoolDb;
            this.config = config;
            this.currentUserService = currentUserService;
        }
        //public List<TopicViewModel> GetAllTopics()
        //{
        //    var response = new List<TopicViewModel>();
        //    var query = schoolDb.Lessons.Where(u => u.Id == 123);
        //    var LessonList = query.ToList();

        //    foreach (var TopicContent in TopicList)
        //    {
        //        var vm = new TopicViewModel
        //        {
        //            Id = Topic.Id,
        //            LessonId = Topic.LesssonId,
        //            Name = Topic.Name,
        //            SequenceNo = Topic.SequenceNo,
        //            LearningExperience = Topic.LearningExperience,
        //            IsActive = Topic.IsActive,
        //            CreatedOn = Topic.CreatedOn

        //        };
        //        response.Add(vm);
        //    }
        //    return response;
        //}
    }
}
