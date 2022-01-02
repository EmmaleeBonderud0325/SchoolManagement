using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Data;
using SchoolManagement.ViewModel.Report;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EssayStudentAnswerReportController : ControllerBase
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly IIdentityService identityService;

        public EssayStudentAnswerReportController(SchoolManagementContext schoolDb, IIdentityService identityService)
        {
            this.schoolDb = schoolDb;
            this.identityService = identityService;
        }

        [HttpGet]
        [Route("getStudents")]
        public List<EssayStudentAnswerReportViewModel> GetEssayStudentAnswerReport()
        {
            var query = schoolDb.EssayStudentAnswers.Where(u => u.Question.Id != null);
            var EssayAnswerList = query.ToList();

            List<EssayStudentAnswerReportViewModel> response = new List<EssayStudentAnswerReportViewModel>();


            foreach (var essayStudentAnswer in EssayAnswerList)
            {
                EssayStudentAnswerReportViewModel vm = new EssayStudentAnswerReportViewModel()
                {
                   QuestionId= essayStudentAnswer.QuestionId,
                   StudentName = essayStudentAnswer.Student.FullName,
                   Marks = essayStudentAnswer.Marks,
                   TeacherComments = essayStudentAnswer.TeacherComments,
                };
                response.Add(vm);
            }
            return response;
        }


        [HttpPost]
        [Route("essayAnswerReport")]
        public ActionResult EssayAnswerReport(EssayStudentAnswerReportViewModel studentAnswerReportViewModel)
        {

            EssayAnswerStudentReport essayAnswerStudentReport = new EssayAnswerStudentReport();
            byte[] abytes = essayAnswerStudentReport.PrepareReport(GetEssayStudentAnswerReport());
            return File(abytes, "application/pdf");

        }

    }
}