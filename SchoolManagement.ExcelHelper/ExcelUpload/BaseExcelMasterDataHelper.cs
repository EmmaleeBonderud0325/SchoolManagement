using Microsoft.Extensions.Configuration;
using SchoolManagement.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ExcelHelper
{
    public class BaseExcelMasterDataHelper
    {
        protected readonly Dictionary<string, string> helpParams;
        protected readonly SchoolManagementContext schoolDb;
        protected readonly IConfiguration config;

        public BaseExcelMasterDataHelper(Dictionary<string, string> helpParams, SchoolManagementContext schoolDb, IConfiguration config)
        {
            this.helpParams = helpParams;
            this.schoolDb = schoolDb;
            this.config = config;
        }
    }
}
