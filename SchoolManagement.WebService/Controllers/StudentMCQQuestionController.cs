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
        [Route("getAll")]
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
        [Route("getAllQuestions")]
        public IActionResult GetAllQuestions()
        {
            var response = studentmcqquestionService.GetAllQuestions();
            return Ok(response);
        }


        [HttpGet]
        [Route("getAllStudentNames")]
        public IActionResult GetAllStudentNames()
        {
            var response = studentmcqquestionService.GetAllStudentNames();
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllStudentAnswerTexts")]
        public IActionResult GetAllStudentAnswerTexts()
        {
            var response = studentmcqquestionService.GetAllStudentAnswerTexts();
            return Ok(response);
        }

        [HttpGet]
        [Route("getStudentNameList")]
        public PaginatedItemsViewModel<BasicStudentMCQQuestionViewModel> GetStudentNameList(string searchText, int currentPage, int pageSize, int studentNameId)
        {
            var response = studentmcqquestionService.GetStudentNameList(searchText, currentPage, pageSize, studentNameId);

            return response;
        }
    }
}
