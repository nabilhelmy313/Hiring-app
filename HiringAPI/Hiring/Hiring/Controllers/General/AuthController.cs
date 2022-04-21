using Application.Interfaces.Services.General;
using Domain.Common;
using Domain.Dto.General.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers.General
{
    [ApiController]
    public class AuthController : ApiControllersBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route(RouteClass.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _userService.Token(loginDto);
            return Ok(token);
        }
    }
}
