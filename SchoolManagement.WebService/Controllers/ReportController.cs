using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IReportService reportService;
        private readonly IIdentityService identityService;

        public ReportController(IConfiguration config, IReportService reportService, IIdentityService identityService)
        {
            this.config = config;
            this.reportService = reportService;
            this.identityService = identityService;
        }

        [HttpGet]
        [Route("downloadUserList")]
        public FileStreamResult DownloadUserList()
        {
            var response = reportService.DownloadUserList();

            return File(new MemoryStream(response.FileData), "application/octet-stream", response.FileName);
        }
    }
}
