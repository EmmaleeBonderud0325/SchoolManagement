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
    public class SubjectStreamController : ControllerBase
    {
        private readonly ISubjectStreamService subjectStreamService;
        private readonly IIdentityService identityService;

        public SubjectStreamController(ISubjectStreamService subjectStreamService, IIdentityService identityService)
        {
            this.subjectStreamService = subjectStreamService;
            this.identityService = identityService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubjectStreamViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = subjectStreamService.SaveSubjectStream(vm, userName);

            return Ok(response);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var response = subjectStreamService.GetAllSubjectStream();
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var response = subjectStreamService.DeleteSubjectStream(id);
            return Ok(response);
        } 

        

       
    }
}
