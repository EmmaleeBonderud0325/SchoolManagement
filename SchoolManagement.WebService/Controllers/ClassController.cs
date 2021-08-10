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
    public class ClassController : ControllerBase
    {
        private readonly IClassService classService;
        private readonly IIdentityService identityService;

        public ClassController(IClassService classService, IIdentityService identityService)
        {
            this.classService = classService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllClasses()
        {
            var response = classService.GetAllClasses();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClassViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await classService.SavaClass(vm, userName);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await classService.DeleteClass(id);
            return Ok(response);
        }

    }
}
