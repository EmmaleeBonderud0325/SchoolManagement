using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.LessonData;
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

        [HttpGet]
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
            var response = lessonDesignService.SaveLesson(vm, userName);
            return Ok(response);
        }
    }
}
