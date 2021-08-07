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
    public class AcademicYearController : ControllerBase
    {
        private readonly IAcademicYearService AcademicYearService;
        private readonly IIdentityService identityService;

        public AcademicYearController(IAcademicYearService academicYearService, IIdentityService identityService)
        {
            this.AcademicYearService = academicYearService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult AcademicYear()
        {
            var response = AcademicYearService.GetAllAcademicYear();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AcademicYearViewModel academicYearVM)
        {
            var userName = identityService.GetUserName();
            var response = await AcademicYearService.SaveAcademicYear(academicYearVM, userName);
            return Ok(response);
        }
    }
}
