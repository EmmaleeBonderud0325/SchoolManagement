using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.ViewModel.Master;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectTeacherController : ControllerBase
    {
        private readonly ISubjectTeacherService subjectTeacherService;
        private readonly IIdentityService identityService;
        
        public SubjectTeacherController(ISubjectTeacherService subjectTeacherService, IIdentityService identityService)
        {
            this.subjectTeacherService = subjectTeacherService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllSubjectTeachers()
        {
            var response = subjectTeacherService.GetAllSubjectTeachers();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubjectTeacherViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await subjectTeacherService.SaveSubjectTeacher(vm, userName);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await subjectTeacherService.DeleteSubjectTeacher(id);
            return Ok(response);
        }
    }
}


