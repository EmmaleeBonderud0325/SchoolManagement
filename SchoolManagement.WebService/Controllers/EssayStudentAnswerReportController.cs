using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Data;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EssayStudentAnswerReportController : ControllerBase
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly IIdentityService identityService;

        public EssayStudentAnswerReportController(SchoolManagementContext schoolDb, IIdentityService identityService)
        {
            this.schoolDb = schoolDb;
            this.identityService = identityService;
        }

   

    }
}