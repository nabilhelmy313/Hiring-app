using Application.Common;
using Application.Interfaces.Repositories.Jobs;
using Application.Interfaces.Services.Employer;
using Application.Resources;
using Domain.Dto.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Employer
{
    public class AddJobService : ServiceBase, IAddJobService
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public AddJobService(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }
        public async Task<ServiceResponse<List<DropDown>>> GetCatgories()
        {
            try
            {

                var jobCategories = await _jobCategoryRepository.GetAllAsync();
                List<DropDown> dropDowns = new();
                jobCategories.ForEach(d =>
                {
                    DropDown dropDown = new()
                    {
                        Id = d.Id,
                        Name = d.Title_En
                    };
                    dropDowns.Add(dropDown);
                });
                return new ServiceResponse<List<DropDown>>
                {
                    Success = true,
                    Data = dropDowns,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.SavedSuccessfully))
                };
            }
            catch (Exception ex)
            {

                return await LogError<List<DropDown>>(ex, null);
            }

        }

    }
}
