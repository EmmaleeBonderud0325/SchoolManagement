using SchoolManagement.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
    public class ClassName
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedOn { get; set; }
		public int CreatedById { get; set; }
		public DateTime UpdatedOn { get; set; }
		public int UpdatedById { get; set; }

		public virtual User CreatedBy { get; set; }
		public virtual User UpdatedBy { get; set; }

		public virtual ICollection<Class> Classes { get; set; }
	}
}
