using Application.Interfaces.Services.Job;
using Domain.Common;
using Domain.Dto.Job.Admin;
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
        [Route(RouteClass.AdminJobCategory.CreateUpdateCategory)]
        public async Task<IActionResult> CreateUpdateCategory([FromForm] CreatejobCategoryDto createjobCategoryDto)
        {
            var response = await _adminJobCategoryService.CreateJobCategory(createjobCategoryDto);
            return Ok(response);
        }
        [HttpPut]
        [Route(RouteClass.AdminJobCategory.DeleteJobCategory)]
        public async Task<IActionResult> DeleteJobCategory([FromQuery] Guid id)
        {
            var response = await _adminJobCategoryService.DeleteJobCategory(id);
            return Ok(response);
        }
        [HttpGet]
        [Route(RouteClass.AdminJobCategory.GetAllJobCategory)]
        public async Task<IActionResult> GetAllJobCategory()
        {
            var response = await _adminJobCategoryService.GetJobCategory();
            return Ok(response);
        }



    }
}
