using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Report
{
    public class EssayStudentAnswerReportViewModel
    {
        public int QuestionId { get; set; }
        public string StudentName { get; set; }
        public string TeacherComments { get; set; }
        public decimal Marks { get; set; }
    }
}
