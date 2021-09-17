using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.AccountData;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
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

        public UserController(IUserService userService, IIdentityService identityService)
        {
            this.userService = userService;
            this.identityService = identityService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await userService.SaveUser(vm, userName);

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllUsers")]
        public ActionResult GetAllUsers(/*DropDownViewModel vm*/)
        {
            var response = userService.GetAllUsersByRole(/*vm*/);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await userService.DeleteUser(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("getUserById/{id}")]
        public ActionResult GetUserById(int id)
        {
            var response = userService.GetUserbyId(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllRoles")]
        public IActionResult GetAllRoles()
        {
            var response = userService.GetAllRoles();

            return Ok(response);
        }

        [HttpGet]
        [Route("getUserMasterData")]
        public UserMasterDataViewModel GetUserMasterData()
        {
            var response = userService.GetUserMasterData();

            return response;
        }

        [HttpGet]
        [Route("getUserList")]
        public PaginatedItemsViewModel<BasicUserViewModel> GetUserList(string searchText, int currentPage, int pageSize, int roleId)
        {
            var response = userService.GetUserList(searchText, currentPage, pageSize, roleId);

            return response;
        }

    }
}
