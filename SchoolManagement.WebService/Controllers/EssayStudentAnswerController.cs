using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.ViewModel.Lesson;
using SchoolManagement.WebService.Infrastructure.Services;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EssayStudentAnswerController : ControllerBase
    {
        private readonly IEssayStudentAnswerService essaystudentanswerService;
        private readonly IIdentityService identityService;

        public EssayStudentAnswerController(IEssayStudentAnswerService essaystudentanswerService, IIdentityService identityService)
        {
            this.essaystudentanswerService = essaystudentanswerService;
            this.identityService = identityService;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] EssayStudentAnswerViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await essaystudentanswerService.SaveEssayStudentAnswer(vm, userName);
            return Ok(response);
        }

        [HttpGet]

        public ActionResult GetAllEssayStudentAnswers()
        {
            var response = essaystudentanswerService.GetAllEssayStudentAnswers();
            return Ok(response);
        }

    }
}
