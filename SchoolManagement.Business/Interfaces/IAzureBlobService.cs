using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces
{
  public interface IAzureBlobService
  {
    Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
  }
}
