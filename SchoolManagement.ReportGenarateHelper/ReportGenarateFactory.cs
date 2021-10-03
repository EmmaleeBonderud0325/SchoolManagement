using Microsoft.Extensions.Configuration;
using SchoolManagement.Data.Data;
using SchoolManagement.ReportGenarateHelper.ReportGenarate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ReportGenarateHelper
{
    public class ReportGenarateFactory
    {
        public BaseReportGenarator GetReportGenarator(Dictionary<string, string> reportParams, SchoolManagementContext schoolDb, IConfiguration config)
        {
            switch (reportParams["reportType"])
            {
                case "User":
                    {
                        return new UserReportGenarateHelper(reportParams, schoolDb, config);
                    }
               
            }

            throw new Exception("Unable to find matching excel uploader");
        }
    }
}
