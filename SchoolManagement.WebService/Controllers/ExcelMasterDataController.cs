using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.ExcelHelper;
using SchoolManagement.ViewModel.Common;
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
    public class ExcelMasterDataController : ControllerBase
    {
        private readonly IExcelMasterDataService excelMasterDataService;
        private readonly IIdentityService identityService;
        public ExcelMasterDataController(IExcelMasterDataService excelMasterDataService, IIdentityService identityService)
        {
            this.excelMasterDataService = excelMasterDataService;
            this.identityService = identityService;

        }

        [HttpPost]
        [Route("uploadExcelData")]
        public async Task<ResponseViewModel> UploadExcelData()
        {
            var userName = identityService.GetUserName();

            var container = new ExcelMasterDataContainerViewModel();
            var request = await Request.ReadFormAsync();

            container.ExcelUploadType = int.Parse(request["ExcelUploadType"]);

            foreach(var file in request.Files)
            {
                container.Files.Add(file);
            }

            var response = await excelMasterDataService.UploadExcelData(container, userName);

            return response;
        }

        [HttpPost]
        [Route("downloadExcelData")]
        [RequestSizeLimit(long.MaxValue)]
        public FileStreamResult DownloadExcelData(ExcelUploadType type)
        {
            var response = excelMasterDataService.DownloadExcelData(type);

            return File(new MemoryStream(response.FileData), "application/octet-stream", response.FileName);
        }


    }
}
