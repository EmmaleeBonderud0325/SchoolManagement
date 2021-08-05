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
    public class ClassSubjectTeacherController : ControllerBase
    {
        private readonly IClassSubjectTeacherService classSubjectTeacherService;
        private readonly IIdentityService identityService;
        public ClassSubjectTeacherController(IClassSubjectTeacherService classSubjectTeacherService, IIdentityService identityService)
        {
            this.classSubjectTeacherService = classSubjectTeacherService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllClassSubjectTeachers()
        {
            var response = classSubjectTeacherService.GetAllClassSubjectTeachers();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClassSubjectTeacherViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await classSubjectTeacherService.SaveClassSubjectTeacher(vm, userName);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await classSubjectTeacherService.DeleteClassSubjectTeacher(id);
            return Ok(response);
        }
    }
}

