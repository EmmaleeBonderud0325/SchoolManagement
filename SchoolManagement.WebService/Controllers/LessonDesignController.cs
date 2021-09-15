using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.ViewModel;
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

        public LessonDesignController(IIdentityService identityService,ILessonDesignService lessonDesignService )
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

        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] TopicViewModel vm)
        //{
        //    var userName = identityService.GetUserName();
        //    var response = await lessonDesignService.SaveTopic(vm, userName);
        //    return Ok(response);
        //}


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
        public PaginatedItemsViewModel<BasicLessonViewModel> GetLessonList(LessonFilterViewModel filters, int cuttrentPage, int pageSize)
        {
            var userName = identityService.GetUserName();
            var response = lessonDesignService.GetLessonList(filters, cuttrentPage, pageSize, userName);

            return response;

        }
    }
}
