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
    public class EssayQuestionAnswerController : ControllerBase
    {
        private readonly IEssayQuestionAnswerService essayquestionanswerService;
        private readonly IIdentityService identityService;

        public EssayQuestionAnswerController(IEssayQuestionAnswerService essayquestionanswerService, IIdentityService identityService)
        {
            this.essayquestionanswerService = essayquestionanswerService;
            this.identityService = identityService;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] EssayQuestionAnswerViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await essayquestionanswerService.SaveEssayQuestionAnswer(vm, userName);
            return Ok(response);
        }

        [HttpGet]

        public ActionResult GetAllEssayQuestionAnswer()
        {
            var response = essayquestionanswerService.GetAllEssayQuestionAnswers();
            return Ok(response);
        }

    }   


}
