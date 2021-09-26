using Microsoft.Extensions.Configuration;
using SchoolManagement.Data.Data;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ExcelHelper
{
    public class AcademicYearAndClassesExcelMasterDataHelper : BaseExcelMasterDataHelper 
    {
        public AcademicYearAndClassesExcelMasterDataHelper(Dictionary<string, string> helpParams, SchoolManagementContext schoolDb, IConfiguration config)
           : base(helpParams, schoolDb, config)
        {

        }

        public override DownloadFileViewModel DownloadExcelData()
        {
            throw new NotImplementedException();
        }

        public override ResponseViewModel UploadExcelData()
        {
            throw new NotImplementedException();
        }
    }
}
