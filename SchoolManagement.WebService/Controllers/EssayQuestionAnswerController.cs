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



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await essayquestionanswerService.DeleteEssayAnswer(id);
            return Ok(response);
        }


        [HttpGet]

        public ActionResult GetAllEssayQuestionAnswer()
        {
            var response = essayquestionanswerService.GetAllEssayQuestionAnswers();
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllQuestions")]
        public IActionResult GetAllQuestions()
        {
            var response = essayquestionanswerService.GetAllQuestions();

            return Ok(response);
        }

        [HttpGet]
        [Route("getQuestionList")]
        public PaginatedItemsViewModel<BasicEssayQuestionAnswerViewModel> GetQuestionList(string searchText, int currentPage, int pageSize, int questionId)
        {
            var response = essayquestionanswerService.GetQuestionList(searchText, currentPage, pageSize, questionId);

            return response;
        }

    }
}
