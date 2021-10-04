using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interfaces.MasterData
{
    public interface IReportService
    {
        DownloadFileModel DownloadUserList();
        DownloadFileModel DownloadStudentList();
        DownloadFileModel DownloadAcademicLevelList();
        DownloadFileModel DownloadClassNameList();
        DownloadFileModel DownloadSubjectsList();
        DownloadFileModel DownloadAcademicLevelSubjectList();
        DownloadFileModel DownloadAcademicYearAndClassesList();
        DownloadFileModel DownloadSubjectTeacherList();
        DownloadFileModel DownloadMcqStudentMarksList();
        DownloadFileModel DownloadEassyStudentMarksList();
       

    }
}
