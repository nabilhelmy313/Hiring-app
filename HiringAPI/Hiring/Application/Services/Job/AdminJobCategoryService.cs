using Application.Common;
using Application.Interfaces.Repositories.General;
using Application.Interfaces.Repositories.Jobs;
using Application.Interfaces.Services.General;
using Application.Interfaces.Services.Job;
using Application.Resources;
using AutoMapper;
using Domain.Dto.Job.Admin;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Job
{
    public class AdminJobCategoryService : ServiceBase, IAdminJobCategoryService
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IAttachmentRepository _attachmentRepository;

        public AdminJobCategoryService(IJobCategoryRepository jobCategoryRepository,
            IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService,IAttachmentRepository attachmentRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _attachmentRepository = attachmentRepository;
        }
        public async Task<ServiceResponse<int>> CreateJobCategory(CreatejobCategoryDto createjobCategoryDto)
        {
            try
            {
                if (createjobCategoryDto == null) return new ServiceResponse<int> { Success = false, Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.DataIsNull)), Data = 0 };
                var map = _mapper.Map<JobCategory>(createjobCategoryDto);
                if (createjobCategoryDto.Id != null)
                {
                    var category = _jobCategoryRepository.FindByID(createjobCategoryDto.Id.Value);
                    category.Title_du = createjobCategoryDto.Title_du;
                    category.Title_En = createjobCategoryDto.Title_En;
                    category.Title_Fr = createjobCategoryDto.Title_Fr;
                    var attach =_attachmentRepository.FindByID(map.Id);
                    if (attach.File_Name != createjobCategoryDto.CategoryPic.FileName)
                    {
                        _attachmentRepository.PhysiscalDelete(map.Id);
                    }
                    await _fileService.UploadFile(map.Id, null, new List<IFormFile> { createjobCategoryDto.CategoryPic }, nameof(map), "000", "JobCategory", 500000);
                }
                else
                {
                    _jobCategoryRepository.Create(map);
                    await _fileService.UploadFile(map.Id, null, new List<IFormFile> { createjobCategoryDto.CategoryPic }, nameof(map), "000", "JobCategory", 500000);
                }
                var res = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int>
                {
                    Success = true,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.SavedSuccessfully)),
                    Data = res
                };
            }
            catch (Exception ex)
            {
                return await LogError(ex, 0);
            }
        }

        public async Task<ServiceResponse<int>> DeleteJobCategory(Guid id)
        {
            try
            {
                _jobCategoryRepository.Delete(id);
                var res = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int>
                {
                    Data = res,
                    Success=true,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.DeletedSuccessfully)),
                };
            }
            catch (Exception ex)
            {
                return await LogError(ex, 0);
            }
        }
    }
}
