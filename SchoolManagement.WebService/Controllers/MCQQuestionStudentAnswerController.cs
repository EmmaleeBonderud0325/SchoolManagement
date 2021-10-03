using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business;
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


        [HttpGet]
        [Route("getAllQuestion")]
        public IActionResult GetAllQuestion()
        {
            var response = mcqquestionstudentanswerService.GetAllQuestion();
            return Ok(response);
        }


        [HttpGet]
        [Route("getAllStudentName")]
        public IActionResult GetAllStudentName()
        {
            var response = mcqquestionstudentanswerService.GetAllStudentName();
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllTeacherAnswer")]
        public IActionResult GetAllTeacherAnswer()
        {
            var response = mcqquestionstudentanswerService.GetAllTeacherAnswer();
            return Ok(response);
        }

        [HttpGet]
        [Route("getStudentList")]
        public PaginatedItemsViewModel<BasicMCQQuestionStudentAnswerViewModel> GetStudentList(string searchText, int currentPage, int pageSize, int studentId, int questionId)
        {
            var response = mcqquestionstudentanswerService.GetStudentList(searchText, currentPage, pageSize, studentId, questionId);

            return response;
        }
    }
}
