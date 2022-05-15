using Application.Common;
using Application.Interfaces.Repositories.General;
using Application.Interfaces.Repositories.Jobs;
using Application.Interfaces.Services.Employer;
using Application.Resources;
using AutoMapper;
using Domain.Dto.Employer;
using Domain.Dto.General;
using Domain.Entities;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;

        public AddJobService(IJobCategoryRepository jobCategoryRepository,
            IUnitOfWork unitOfWork,IMapper mapper,IJobRepository jobRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jobRepository = jobRepository;
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

        public async Task<ServiceResponse<int>> AddJob(AddJobDto addJobDto)
        {
            try
            {
                var  job = _mapper.Map<Job>(addJobDto);
                 _jobRepository.Create(job);
                var res = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int>
                {
                    Data = res,
                    Success=true,
                    Message= CultureHelper.GetResourceMessage(Resource.ResourceManager,Resource.Added)
                };
            }
            catch (Exception ex)
            {
                return await LogError(ex, 0);
            }
        }

        public async Task<ServiceResponse<int>> DeleteJob(Guid id)
        {
            try
            {
                _jobRepository.Delete(id);
                var res = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int>
                {
                    Data = res,
                    Success = true,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, Resource.DeletedSuccessfully)
                };
            }
            catch (Exception ex)
            {

                return await LogError(ex, 0);
            }

        }
    }
}
