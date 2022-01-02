using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util.Tenant
{
    public interface ITenantProvider
    {
        Task<TenantSchool> GetTenant();
        
    }
}
