using Application.Interfaces.Repositories.General;
using Application.Interfaces.Repositories.Jobs;
using Application.Interfaces.Services.General;
using Application.Interfaces.Services.Home;
using AutoMapper;
using Domain.Dto.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Home
{
    public class HomeJobCategoryService:ServiceBase,IHomeJobCategoryService
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IAttachmentRepository _attachmentRepository;

        public HomeJobCategoryService(IJobCategoryRepository jobCategoryRepository,
            IJobRepository jobRepository,
            IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService,
            IAttachmentRepository attachmentRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _attachmentRepository = attachmentRepository;
        }


        public async Task<ServiceResponse<List<GetHomeJobCategoriesDto>>> GetJobCategories()
        {
            try
            {
                var jobCategories = await _jobCategoryRepository.GetAllAsync();

                
                List<GetHomeJobCategoriesDto> getHomeJobCategoriesDtos = new();
               


                var map = _mapper.Map<List<GetHomeJobCategoriesDto>>(jobCategories);

                for (int i = 0; i < map.Count; i++)
                {
                    var x = (await _attachmentRepository.GetAllAsync(p => p.Row_Id == map[i].Id.ToString())).FirstOrDefault().File_Path;
                    //var p = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/{x}";
                    map[i].CategoryPic = x;
                    map[i].JobCount = _jobCategoryRepository.GetJobCount(map[i].Id);
                }
                return new ServiceResponse<List<GetHomeJobCategoriesDto>>
                {
                    Data = map,
                    Success = true
                };
            }
            catch (Exception ex)
            {

                return await LogError<List<GetHomeJobCategoriesDto>>(ex, null);
            }
        }

    }

}

