using Application.Interfaces.Services.Admin;
using Domain.Common;
using Domain.Dto.JobAdmin.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers.Admin
{
    public class AdminJobCategoryController : ApiControllersBase
    {
        private readonly IAdminJobCategoryService _adminJobCategoryService;

        public AdminJobCategoryController(IAdminJobCategoryService adminJobCategoryService)
        {
            _adminJobCategoryService = adminJobCategoryService;
        }
        [HttpPost]
        [Route(RouteClass.AdminJobCategoryRoute.CreateUpdateCategory)]
        public async Task<IActionResult> CreateUpdateCategory([FromForm] CreatejobCategoryDto createjobCategoryDto)
        {
            var response = await _adminJobCategoryService.CreateJobCategory(createjobCategoryDto);
            return Ok(response);
        }
        [HttpPut]
        [Route(RouteClass.AdminJobCategoryRoute.DeleteJobCategory)]
        public async Task<IActionResult> DeleteJobCategory([FromQuery] Guid id)
        {
            var response = await _adminJobCategoryService.DeleteJobCategory(id);
            return Ok(response);
        }
        [HttpGet]
        [Route(RouteClass.AdminJobCategoryRoute.GetAllJobCategory)]
        public async Task<IActionResult> GetAllJobCategory()
        {
            var response = await _adminJobCategoryService.GetJobCategory();
            return Ok(response);
        }
    }
}
