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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IIdentityService identityService;

        public StudentController(IStudentService studentService, IIdentityService identityService)
        {
            this.studentService = studentService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllStudents()
        {
            var response = studentService.GetAllStudent();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentViewModel studentViewModel)
        {
            var userName = identityService.GetUserName();
            var response = await studentService.SaveStudent(studentViewModel, userName);
            return Ok(response);
        }
        //"{id}"
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await studentService.DeleteStudent(id);
            return Ok(response);
        }
    }
}
