using SchoolManagement.Model;
using SchoolManagement.Model.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master.Subject
{
    public class BasicSubjectViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public int SubjectStreamId { get; set; }
        public SubjectCategory SubjectCategory { get; set; }
        public string SubjectCategoryName { get; set; }
        public SubjectType SubjectType { get; set; }
        public int? ParentBasketSubjectId { get; set; }
        public string ParentBasketSubjectName { get; set; }
        public string SubjectStreamName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedByName { get; set; }
    }
}
