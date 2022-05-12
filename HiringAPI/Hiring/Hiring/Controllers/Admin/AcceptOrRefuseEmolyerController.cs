using Application.Interfaces.Services.Admin;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers.Admin
{
    public class AcceptOrRefuseEmolyerController : ApiControllersBase
    {
        private readonly IAcceptOrRefuseEmolyerServcie _AcceptOrRefuseEmolyerServcie;
        public AcceptOrRefuseEmolyerController(IAcceptOrRefuseEmolyerServcie acceptOrRefuseEmolyerServcie)
        {
            _AcceptOrRefuseEmolyerServcie = acceptOrRefuseEmolyerServcie;
        }

        [HttpGet]
        [Route(RouteClass.Admin.GetEmployers)]
        public async Task<IActionResult> GetEmployers(string RoleName) {
            var result =await _AcceptOrRefuseEmolyerServcie.GetEmployers(RoleName);
            return Ok( result);
        }

        [HttpPut]
        [Route(RouteClass.Admin.UpdateActivationOfUser)]
        public async Task<IActionResult> UpdateActivationOfUser(string UserId)
        {
            var result = await _AcceptOrRefuseEmolyerServcie.UpdateActivationOfUser(UserId);
            return Ok(result);
        }



    }
}
