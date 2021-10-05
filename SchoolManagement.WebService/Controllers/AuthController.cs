using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interfaces;
using SchoolManagement.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel vm)
        {
            var response = authService.Login(vm);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("forgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel vm)
        {
            var response =  authService.ForgotPassword(vm);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("resetPassword")]
        public IActionResult ResetPassword(ResetPasswordViewModel vm)
        {
            var response = authService.ResetPassword(vm);

            return Ok(response);
        }
    }
}
