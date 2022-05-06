using Application.Interfaces.Services.Job;
using Domain.Common;
using Domain.Dto.Job.Admin;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> CreateUpdateCategory([FromBody] CreatejobCategoryDto createjobCategoryDto)
        {
            var response = await _adminJobCategoryService.CreateJobCategory(createjobCategoryDto);
            return Ok(response);
        }
        [HttpDelete]
        [Route(RouteClass.AdminJobCategory.CreateUpdateCategory)]
        public async Task<IActionResult> DeleteJobCategory([FromBody] Guid id)
        {
            var response = await _adminJobCategoryService.DeleteJobCategory(id);
            return Ok(response);
        }
    }
}
