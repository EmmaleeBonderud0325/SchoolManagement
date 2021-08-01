using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.AccountData;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IIdentityService identityService;

        public UserController(IUserService userService,IIdentityService identityService)
        {
            this.userService = userService;
            this.identityService = identityService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]UserViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = userService.SaveUser(vm, userName);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var response = userService.GetAllUsers();
            return Ok(response);
        }
    }
}
