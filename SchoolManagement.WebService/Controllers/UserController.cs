using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces.AccountData;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Account;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Authorize]
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
        public ActionResult GetAllUsers()
        {
            var response = userService.GetAllUsersByRole();

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

        [HttpGet]
        [Route("getUserDetail")]
        public UserMasterViewModel GetUserDetail()
        {
            var userName = identityService.GetUserName();

            var response = userService.GetUserDetail(userName);

            return response;
        }

        [HttpPost]
        [Route("updateUserMasterData")]
        public async Task<ActionResult> UpdateUserMasterData([FromBody] UserMasterViewModel vm)
        {
            var userName = identityService.GetUserName();
            var response = await userService.UpdateUserMasterData(vm, userName);

            return Ok(response);
        }

    [HttpPost]
    [RequestSizeLimit(long.MaxValue)]
    [Route("uploadUserImage")]
    public async Task<IActionResult> UploadUserImage()
    {
      var userName = identityService.GetUserName();

      var container = new FileContainerViewModel();

      var request = await Request.ReadFormAsync();

      //container.Id = int.Parse(request["id"]);

      foreach (var file in request.Files)
      {
        container.Files.Add(file);
      }

      var response = await userService.UploadUserImage(container, userName);

      return Ok(response);
    }


    [HttpGet]
        [RequestSizeLimit(long.MaxValue)]
        [Route("downloadUserList")]
        public FileStreamResult downloadUserListReport()
        {
            var response = userService.downloadUserListReport();

            return File(new MemoryStream(response.FileData), "application/pdf", response.FileName);
        }



    }
}
