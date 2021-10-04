using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data.Data;
using SchoolManagement.ViewModel.Lesson;
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
    public class StudentMcqQuestionReportController : ControllerBase
    {
        private readonly SchoolManagementContext schoolDb;
        private readonly IIdentityService identityService;

        public StudentMcqQuestionReportController(SchoolManagementContext schoolDb, IIdentityService identityService)
        {
            this.schoolDb = schoolDb;
            this.identityService = identityService;
        }

        [HttpGet]
        [Route("getStudents")]
        public List<StudentReportViewModel> GetStudents()
        {
            var query = schoolDb.StudentMCQQuestions.Where(u => u.Question.Id != null);
            var QuestionList = query.ToList();

            List<StudentReportViewModel> response = new List<StudentReportViewModel>();
            

            foreach (var studentReportViewModel in QuestionList)
            {
                StudentReportViewModel vm = new StudentReportViewModel()
                {
                    StudentId = studentReportViewModel.StudentId,
                    StudentName =studentReportViewModel.Student.User.FullName,
                    Marks = studentReportViewModel.Marks
                };
                response.Add(vm);
            }
            return response;
        }


        [HttpPost]
        [Route("report")]
        public ActionResult Report(StudentReportViewModel studentReportViewModel)
        {

            StudentReport studentReport = new StudentReport();
            byte[] abytes = studentReport.PrepareReport(GetStudents());
            return File(abytes, "application/pdf");

        }

    }
}