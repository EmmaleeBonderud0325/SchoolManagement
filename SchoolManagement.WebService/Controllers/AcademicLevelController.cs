using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.MasterData;
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

        public AcademicLevelController(IAcademicLevelService AcademicLevelService)
        {
            this.AcademicLevelService = AcademicLevelService;
        }

        [HttpGet]
        public ActionResult AcademicLevel()
        {
            var response = AcademicLevelService.GetAllAcademicLevel();
            return Ok(response);
        }
    }
}
