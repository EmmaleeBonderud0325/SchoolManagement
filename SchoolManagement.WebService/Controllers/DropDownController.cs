using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        private readonly IDropDownService dropDownService;
        private readonly IIdentityService identityService;
        public DropDownController(IDropDownService dropDownService, IIdentityService identityService)
        {
            this.dropDownService = dropDownService;
            this.identityService = identityService;
        }

        [HttpGet]
        [Route("getSubjectTypes")]
        public ActionResult GetSubjectType()
        {
            var response = dropDownService.GetSubjectTypes();

            return Ok(response);
        }

        [HttpGet]
        [Route("getSubjectCategorys")]
        public ActionResult SubjectCategory()
        {
            var response = dropDownService.GetAllSubjectCategorys();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllParentBasketSubjects")]
        public ActionResult getAllParentBasketSubjects()
        {
            var response = dropDownService.GetAllParentBasketSubjects();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllAcademicLevels")]
        public IActionResult GetAllAcademicLevels()
        {
            var response = dropDownService.GetAllAcademicLevels();
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllSubjectStreams")]
        public ActionResult GetAllSubjectStreams()
        {
            var response = dropDownService.GetAllSubjectStreams();
            return Ok(response);
        }

       


    }


}
