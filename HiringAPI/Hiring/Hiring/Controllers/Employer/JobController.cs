using Application.Interfaces.Services.Employer;
using Domain.Common;
using Domain.Dto.Employer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiring.Controllers.Employer
{
    [ApiController]
    public class JobController : ApiControllersBase
    {
        private readonly IAddJobService _addJobService;

        public JobController(IAddJobService addJobService )
        {
            _addJobService = addJobService;
        }
        [Route(RouteClass.JobRoute.GetCatgories)]
        [HttpGet]
        public async Task<IActionResult> GetCatgories()
        {
            var res =await _addJobService.GetCatgories();
            return Ok(res);
        }
        [Route(RouteClass.JobRoute.AddJob)]
        [HttpPost]
        public async Task<IActionResult> AddJob(AddJobDto addJobDto)
        {
            var res = await _addJobService.AddJob(addJobDto);
            return Ok(res);
        }
        [Route(RouteClass.JobRoute.DeleteJob)]
        [HttpPut]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            var res = await _addJobService.DeleteJob(id);
            return Ok(res);
        }
    }
}
