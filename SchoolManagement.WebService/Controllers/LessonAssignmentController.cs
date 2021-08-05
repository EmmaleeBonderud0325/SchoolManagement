using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.LessonData;
using SchoolManagement.Business;
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
    public class LessonAssignmentController : ControllerBase
    {
        private readonly ILessonAssignmentService lessonassignmentService;
        private readonly IIdentityService identityService;

        public LessonAssignmentController(ILessonAssignmentService lessonassignmentService, IIdentityService identityService)
        {
            this.lessonassignmentService = lessonassignmentService;
            this.identityService = identityService;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] LessonAssignmentViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await lessonassignmentService.SaveLessonAssignment(vm, userName);
            return Ok(response);
        }

        [HttpGet]

        public ActionResult GetLessonAssignments()
        {
            var response = lessonassignmentService.GetLessonAssignments();
            return Ok(response);
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete(int Id)
        {
            var response = await lessonassignmentService.DeleteLessonAssignment( Id);
            return Ok(response);
        }
    }
}
