using Microsoft.Extensions.Configuration;
using SchoolManagement.Data.Data;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ReportGenarateHelper.ReportGenarate
{
    public class UserReportGenarateHelper :BaseReportGenarator
    {
        public UserReportGenarateHelper(Dictionary<string, string> reportParams, SchoolManagementContext schoolDb, IConfiguration config)
            :base(reportParams, schoolDb, config)
        {

        }

        public override DownloadFileModel GenaratePDFReport()
        {
            return base.GenaratePDFReport();
        }
        public override DownloadFileModel GenerateExcelReport()
        {
            return base.GenerateExcelReport();
        }
    }
}
