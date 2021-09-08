using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business;
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
    public class StudentMCQQuestionController : ControllerBase
    {
        private readonly IStudentMCQQuestionService studentmcqquestionService;
        private readonly IIdentityService identityService;

        public StudentMCQQuestionController(IStudentMCQQuestionService studentmcqquestionService, IIdentityService identityService)
        {
            this.studentmcqquestionService = studentmcqquestionService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllStudentMCQQuestion()
        {
            var response = studentmcqquestionService.GetAllStudentMCQQuestions();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentMCQQuestionViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await studentmcqquestionService.SaveStudentMCQQuestion(vm, userName);
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllQuestion")]
        public IActionResult GetAllQuestion()
        {
            var response = studentmcqquestionService.GetAllQuestion();
            return Ok(response);
        }


        [HttpGet]
        [Route("getAllStudentName")]
        public IActionResult GetAllStudentName()
        {
            var response = studentmcqquestionService.GetAllStudentName();
            return Ok(response);
        }
    }
}
