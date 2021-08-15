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
    public class AcademicLevelController : ControllerBase
    {
        private readonly IAcademicLevelService AcademicLevelService;
        private readonly IIdentityService identityService;

        public AcademicLevelController(IAcademicLevelService AcademicLevelService , IIdentityService identityService)
        {
            this.AcademicLevelService = AcademicLevelService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var response = AcademicLevelService.GetAllAcademicLevel();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AcademicLevelViewModel academicLevelVM)
        {
            var userName = identityService.GetUserName();
            var response = await AcademicLevelService.SaveAcademicLevel(academicLevelVM, userName);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await AcademicLevelService.DeleteAcademicLevel(id);
            return Ok(response);
        }
    }
}
