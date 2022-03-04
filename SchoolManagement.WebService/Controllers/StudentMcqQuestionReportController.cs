using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Data;
using SchoolManagement.ViewModel.Lesson;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMcqQuestionReportController : ControllerBase
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly IIdentityService identityService;

        public StudentMcqQuestionReportController(SchoolManagementContext schoolDb, IIdentityService identityService)
        {
            this.schoolDb = schoolDb;
            this.identityService = identityService;
        }

 

    }
}