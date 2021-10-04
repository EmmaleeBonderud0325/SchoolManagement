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
    public abstract class BaseReportGenarator
    {
        protected readonly Dictionary<string, string> reportParams;
        private readonly SchoolManagementContext schoolDb;
        protected readonly IConfiguration config;

        public BaseReportGenarator(Dictionary<string, string> reportParams, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.reportParams = reportParams;
            this.schoolDb = schoolDb;
            this.config = config;
        }

        public virtual DownloadFileModel GenaratePDFReport()
        {
            throw new NotImplementedException("Method has not implemented.");
        }
        public virtual DownloadFileModel GenerateExcelReport()
        {
            throw new NotImplementedException("Method has not implemented.");
        }
    }
    
}
