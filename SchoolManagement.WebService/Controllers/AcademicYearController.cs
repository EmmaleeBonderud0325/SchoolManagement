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
    public class AcademicYearController : ControllerBase
    {
        private readonly IAcademicYearService AcademicYearService;

        public AcademicYearController(IAcademicYearService AcademicYearService)
        {
            this.AcademicYearService = AcademicYearService;
        }

        [HttpGet]
        public ActionResult AcademicYear()
        {
            var response = AcademicYearService.GetAllAcademicYear();
            return Ok(response);
        }
    }
}
