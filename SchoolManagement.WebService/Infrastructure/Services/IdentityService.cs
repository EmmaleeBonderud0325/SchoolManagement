using Microsoft.AspNetCore.Http;
using SchoolManagement.Data.Common;
using SchoolManagement.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;
       

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
           
        }

        public string GetUserIdentity()
        {
            var value = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return value;
        }

        public string GetUserName()
        {
            var identity = _context.HttpContext.User.Identity as ClaimsIdentity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            var username = claim != null ? claim.Value : string.Empty;
           
            return username;
        }
    }
}
