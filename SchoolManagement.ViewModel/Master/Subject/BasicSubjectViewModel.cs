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
        public int CategorysId { get; set; }
        public string SubjectCategoryName { get; set; }
        public string ParentBasketSubjectName { get; set; }
        public string SubjectStreamName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedByName { get; set; }
    }
}
