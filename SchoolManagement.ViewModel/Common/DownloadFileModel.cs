using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Common
{
    public class DownloadFileModel
    {
        public bool IsGenerationSuccess { get; set; }
        public byte[] FileData { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
    }
}
