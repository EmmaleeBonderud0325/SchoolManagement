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
        public ActionResult GetClasses()
        {
            var response = classService.GetClasses();
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

        [HttpGet]
        [Route("getAllClassNames")]
        public ActionResult GetAllClassNames()
        {
            var response = classService.GetAllClassNames();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllAcademicLevels")]
        public ActionResult GetAllAcademicLevels()
        {
            var response = classService.GetAllAcademicLevels();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllAcademicYears")]
        public ActionResult GetAllAcademicYears()
        {
            var response = classService.GetAllAcademicYears();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllClassCategories")]
        public ActionResult GetAllClassCategories()
        {
            var response = classService.GetAllClassCategories();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllLanguageStreams")]
        public ActionResult GetAllLanguageStreams()
        {
            var response = classService.GetAllLanguageStreams();

            return Ok(response);
        }
    }
}
