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
    public class HeadOfDepartmentController : ControllerBase
    {
        private readonly IHeadOfDepartmentService HeadOfDepartmentService;

        public HeadOfDepartmentController(IHeadOfDepartmentService HeadOfDepartmentService)
        {
            this.HeadOfDepartmentService = HeadOfDepartmentService;
        }

        [HttpGet]
        public ActionResult HeadOfDepartment()
        {
            var response = HeadOfDepartmentService.GetAllHeadOfDepartment();
            return Ok(response);
        }
    }
}
