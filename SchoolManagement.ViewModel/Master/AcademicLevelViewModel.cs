using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Master
{
    public class AcademicLevelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelHeadId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedById { get; set; }

    }
}
