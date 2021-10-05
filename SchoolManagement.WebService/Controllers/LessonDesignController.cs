using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.Model;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.ViewModel.Lesson;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonDesignController : ControllerBase
    {
        private readonly IIdentityService identityService;
        private readonly ILessonDesignService lessonDesignService;

        public LessonDesignController(IIdentityService identityService, ILessonDesignService lessonDesignService)
        {
            this.identityService = identityService;
            this.lessonDesignService = lessonDesignService;

        }

        [HttpPost]
        [Route("getAllLessons")]
        public ActionResult GetAllLessons(LessonFilterViewModel filters)
        {
            var userName = identityService.GetUserName();
            var response = lessonDesignService.GetAllLessons(filters, userName);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LessonViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await lessonDesignService.SaveLesson(vm, userName);
            return Ok(response);
        }
        [HttpGet("GetAllTopics")]
        public ActionResult GetAllTopics(LessonFilterViewModel filters)
        {
            var userName = identityService.GetUserName();
            var response = lessonDesignService.GetAllLessons(filters, userName);
            return Ok(response);
        }

        [HttpPost]
        [Route("saveTopic")]
        public async Task<ActionResult> SaveTopic([FromBody] TopicViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await lessonDesignService.SaveTopic(vm, userName);
            return Ok(response);
        }


        [HttpPost]
        [Route("saveTopicContent")]
        public async Task<ActionResult> SaveTopicContent(TopicContentViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await lessonDesignService.SaveTopicContent(vm, userName);
            return Ok(response);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var response = await lessonDesignService.DeleteLesson(Id);
            return Ok(response);
        }

        [HttpGet]
        [Route("getLessonMasterData")]
        public LessonMasterDataViewModel GetLessonMasterData()
        {
            var response = lessonDesignService.GetLessonMasterData();

            return response;
        }

        [HttpGet]
        [Route("getLessonList")]
        public PaginatedItemsViewModel<BasicLessonViewModel> GetLessonList(string searchText, int academicYearId, int academicLevelId,
                                                                            int currentPage, int classNameId, int subjectId, int pageSize)
        {
            var userName = identityService.GetUserName();
            var response = lessonDesignService.GetLessonList(searchText, academicYearId, academicLevelId,
                                                                            currentPage, classNameId, subjectId, pageSize, userName);

            return response;

        }

        [HttpGet]
        [Route("getLessonById/{id}")]
        public ActionResult GetLessonById(int id)
        {
            var response = lessonDesignService.GetLessonById(id);

            return Ok(response);
        }
        [HttpPost]
        [Route("createNewLesson")]
        public async Task<LessonViewModel> CreateNewLesson()
        {
            var userName = identityService.GetUserName();
            var response = await lessonDesignService.CreateNewLesson(userName);

            return response;
        }

    //[Authorize(Roles = AuthorizedRoles.Admin)]
    [HttpPost]
    [RequestSizeLimit(long.MaxValue)]
    [Route("uploadLessonFile")]
    public async Task<IActionResult> UploadLessonFile()
    {
      var userName = identityService.GetUserName();

      var container = new FileContainerViewModel();

      var request = await Request.ReadFormAsync();

      var id = int.Parse(request["id"]);
      var topicId = int.Parse(request["topicId"]);
      var contentType = int.Parse(request["contentType"]);

      foreach (var file in request.Files)
      {
        container.Files.Add(file);
      }

      var topic = new TopicContentViewModel()
      {
        Id = id,
        TopicId = topicId,
        ContentType = (TopicContentType)contentType
      };

      var response = await lessonDesignService.UploadTopicContentFile(topic,request.Files.FirstOrDefault(), userName);

      return Ok(response);
    }

  }   
}
