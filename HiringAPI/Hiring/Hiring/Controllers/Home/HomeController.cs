using Application.Interfaces.Services.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers.Home
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeJobCategoryService _homeJobCategoryService;
        public HomeController(IHomeJobCategoryService homeJobCategoryService)
        {
            _homeJobCategoryService = homeJobCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJobCategory()
        {
            var response = await _homeJobCategoryService.GetJobCategories();
            return Ok(response);
        }
    }

}

