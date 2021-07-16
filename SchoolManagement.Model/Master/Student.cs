using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class Student
    {
        public int ID { get; set; }
        public int AdmissionNo { get; set; }
        public string EmegencyContactNo1 { get; set; }
        public string EmegencyContactNo2 { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        //public virtual User UserID { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
