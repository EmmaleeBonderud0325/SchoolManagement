using Microsoft.Extensions.Configuration;
using SchoolManagement.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ExcelHelper
{
    public class FIleUploadFactory
    {
        public BaseExcelMasterDataHelper GetExcelUploader(Dictionary<string, string> helpParams, SchoolManagementContext schoolDb, IConfiguration config)
        {
            switch (helpParams["FileType"])
            {
                case "User":
                    {
                        return new UserExcelMasterDataHelper(helpParams, schoolDb, config);
                    }
                case "Student":
                    {
                        return new StudentExcelMasterDataHelper(helpParams, schoolDb, config);
                    }
            }

            throw new Exception("Unable to find matching excel uploader");
        }
    }
}
