using SchoolManagement.ExcelHelper;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IExcelMasterDataService
    {
        Task<ResponseViewModel> UploadExcelData(ExcelMasterDataContainerViewModel container, string userName);
        DownloadFileViewModel DownloadExcelData(ExcelUploadType excelType);
    }
}
