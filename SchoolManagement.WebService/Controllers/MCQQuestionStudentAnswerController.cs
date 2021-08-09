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
    public class MCQQuestionStudentAnswerController : ControllerBase
    {
        private readonly IMCQQuestionStudentAnswerService mcqquestionstudentanswerService;
        private readonly IIdentityService identityService;

        public MCQQuestionStudentAnswerController (IMCQQuestionStudentAnswerService mcqquestionstudentanswerService, IIdentityService identityService)
        {
            this.mcqquestionstudentanswerService = mcqquestionstudentanswerService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllMCQQuestionStudentAnswer()
        {
            var response = mcqquestionstudentanswerService.GetAllMCQQuestionStudentAnswers();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MCQQuestionStudetAnswerViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await mcqquestionstudentanswerService.SaveMCQQuestionStudentAnswer(vm, userName);
            return Ok(response);
        }
    }
}
