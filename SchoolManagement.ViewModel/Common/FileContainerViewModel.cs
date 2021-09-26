using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Common
{
    public class FileContainerViewModel
    {
        public FileContainerViewModel()
        {
            Files = new List<IFormFile>();
        }
        public List<IFormFile> Files { get; set; }
        
        
    }
}
