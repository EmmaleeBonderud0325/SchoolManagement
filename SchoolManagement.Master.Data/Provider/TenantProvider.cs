using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.Util.Tenant;
using SchoolManagement.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Master.Data.Provider
{
    public class TenantProvider : ITenantProvider
    {
        private readonly MasterDbContext dbContext;
        private readonly IHttpContextAccessor accessor;
        private  List<TenantSchool> tenantSchools;

        public TenantProvider(MasterDbContext dbContext, IHttpContextAccessor accessor)
        {
            this.dbContext = dbContext;
            this.accessor = accessor;
            LoadTenants();
        }
        public async Task<TenantSchool> GetTenant()
        {
            var identity = accessor.HttpContext.User.Identity as ClaimsIdentity;
            if(identity.Claims.Count() > 0 )
            {
                var secretKey = identity.FindFirst("SecretKey").Value;

                var matchingTenantSchool = tenantSchools.FirstOrDefault(x => x.SecretKey.ToUpper() == secretKey.ToUpper());

                return matchingTenantSchool;
            }
            else
            {
                var loginRequest = accessor.HttpContext.Request.Body;
                using(var reader = new StreamReader(loginRequest, Encoding.UTF8))
                {
                    var value = await reader.ReadToEndAsync();

                    var loginVm = JsonConvert.DeserializeObject<LoginViewModel>(value);

                    var matchingTenantSchool = tenantSchools.FirstOrDefault(x => x.SchoolDomain.ToUpper() == loginVm.SchoolDomain.ToUpper());

                    accessor.HttpContext.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(value));

                    return matchingTenantSchool;
                }
            }
        }
        private void LoadTenants()
        {
            tenantSchools = dbContext.Schools.Where(a => a.IsActive == true).Select(x => new TenantSchool()
            {
                Id = x.Id,
                SchoolName = x.SchoolName,
                SchoolDomain = x.SchoolDomain,
                SchoolLogo = x.SchoolLogo,
                ConnectionString = x.ConnectionString,
                SMTPServer = x.SMTPServer,
                SMTPUsername = x.SMTPUsername,
                SMTPPassword = x.SMTPPassword,
                SMTPFrom = x.SMTPFrom,
                SMTPPort = x.SMTPPort,
                IsSMTPUseSSL = x.IsSMTPUseSSL,
                TenantId = x.TenantId.ToString(),
                APIKey = x.APIKey.ToString(),
                SecretKey = x.SecretKey.ToString(),
                IsActive = x.IsActive

            }).ToList();
        }
        

    }
}
