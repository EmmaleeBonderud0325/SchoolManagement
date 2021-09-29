using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.ExcelHelper;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Master
{
    public class ExcelMasterDataService : IExcelMasterDataService
    {
        public DownloadFileViewModel DownloadExcelData(ExcelUploadType excelType)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel> UploadExcelData(ExcelMasterDataContainerViewModel container, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
