﻿using Microsoft.AspNetCore.Http;
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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        private readonly IIdentityService identityService;

        public SubjectController(ISubjectService subjectService, IIdentityService identityService)
        {
            this.subjectService = subjectService;
            this.identityService = identityService;
        }

        [HttpGet]
        public ActionResult GetAllSubjects()
        {
            var response = subjectService.GetAllSubjects();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubjectViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await subjectService.SaveSubject(vm, userName);
            return Ok(response);
        }


    }
}
