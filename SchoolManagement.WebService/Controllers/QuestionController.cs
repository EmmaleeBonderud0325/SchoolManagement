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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;
        private readonly IIdentityService identityService;

        public QuestionController(IQuestionService questionService, IIdentityService identityService)
        {
            this.questionService = questionService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllQuestion() 
        {
            var response = questionService.GetAllQuestions();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] QuestionViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await questionService.SaveQuestion(vm, userName);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var response = await questionService.DeleteQuestion(Id);
            return Ok(response);

        }
    }
}
