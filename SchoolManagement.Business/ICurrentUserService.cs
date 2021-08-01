using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public interface ICurrentUserService
    {
        User GetUserByUsername(string userName);
    }
}
