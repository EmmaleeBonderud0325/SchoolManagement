using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Lesson;
using SchoolManagement.WebService.Infrastructure.Services;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonAssignmentSubmissionController : ControllerBase
    {
        private readonly ILessonAssignmentSubmissionService lessonassignmentsubmissionService;
        private readonly IIdentityService identityService;

        public LessonAssignmentSubmissionController(ILessonAssignmentSubmissionService lessonassignmentsubmissionService, IIdentityService identityService)
        {
            this.lessonassignmentsubmissionService = lessonassignmentsubmissionService;
            this.identityService = identityService;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] LessonAssignmentSubmissionViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await lessonassignmentsubmissionService.SaveLessonAssignmentSubmission(vm, userName);
            return Ok(response);
        }

        [HttpGet]

        public ActionResult GetLessonAssignmentSubmissions()
        {
            var response = lessonassignmentsubmissionService.GetLessonAssignmentSubmissions();
            return Ok(response);
        }


        [HttpGet]
        [Route("getAllStudents")]
        public IActionResult GetAllStudents()
        {
            var response = lessonassignmentsubmissionService.GetAllStudents();

            return Ok(response);
        }


        [HttpGet]
        [Route("getAllLessonAssignments")]
        public IActionResult GetAllLessonAssignments()
        {
            var response = lessonassignmentsubmissionService.GetAllLessonAssignments();

            return Ok(response);
        }

        [HttpGet]
        [Route("getLessonAssignmentsList")]
        public PaginatedItemsViewModel<BasicLessonAssignmnetSubmissionViewModel> GetLessonAssignmentsList(string searchText, int currentPage, int pageSize, int lessonassignmentId)
        {
            var response = lessonassignmentsubmissionService.GetLessonAssignmentsList(searchText, currentPage, pageSize, lessonassignmentId);

            return response;
        }

    }
}
