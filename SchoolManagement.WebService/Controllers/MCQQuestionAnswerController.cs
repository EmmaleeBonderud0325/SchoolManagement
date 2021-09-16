using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.Model;
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
    public class MCQQuestionAnswerController : ControllerBase
    {
        private readonly IMCQQuestionAnswerService mcqQuestionAnswerService;
        private readonly IIdentityService identityService;

        public MCQQuestionAnswerController(IMCQQuestionAnswerService mcqquestionanswerService, IIdentityService identityService)
        {
            this.mcqQuestionAnswerService = mcqquestionanswerService;
            this.identityService = identityService;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetMCQQuestionAnswers()
        {
            var response = mcqQuestionAnswerService.GetMCQQuestionAnswers();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MCQQuestionAnswerViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await mcqQuestionAnswerService.SaveMCQQuestionAnswer(vm, userName);
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllQuestions")]
        public IActionResult GetAllQuestions()
        {
            var response = mcqQuestionAnswerService.GetAllQuestions();
            return Ok(response);
        }
    }
}
