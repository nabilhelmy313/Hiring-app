using Application.Common;
using Application.Interfaces.Repositories.General;
using Application.Interfaces.Repositories.General.Auth;
using Application.Interfaces.Services.Admin;
using Application.Resources;
using AutoMapper;
using Domain.Dto.Admin;
using Domain.Entities.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin
{
    public class AcceptOrRefuseEmolyerServcie:   ServiceBase, IAcceptOrRefuseEmolyerServcie
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        public AcceptOrRefuseEmolyerServcie(IUnitOfWork unitOfWork,   UserManager<ApplicationUser> userManager, IAppUserRepository appUserRepository, UserManager<ApplicationUser> _userManager, IMapper mapper)
        {
             _unitOfWork = unitOfWork;
            _appUserRepository = appUserRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<List<GetEmployerInfoDto>>> GetEmployers(string RoleName)
        {
            try
            {
                var users = await _appUserRepository.GetEmployers();
                if (users == null) return new ServiceResponse<List<GetEmployerInfoDto>>() { Success = false, Data = null, Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.DataIsNull)) };
                var Mapped = _mapper.Map<List<GetEmployerInfoDto>>(users);
                return new ServiceResponse<List<GetEmployerInfoDto>>() { Success = true, Data = Mapped };
            }
            catch (Exception ex )
            {
                return await LogError<List<GetEmployerInfoDto>>(ex,null); 
            }
        }

        public async Task<ServiceResponse<bool>> UpdateActivationOfUser(string userId)
        {
            try
            {
                var User = await _appUserRepository.GetUserById(Guid.Parse(userId));
                if(User is null) return new ServiceResponse<bool>() { Success = false,Data=false,Message= CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.DataIsNull)) };
                User.IsActive = !User.IsActive;
                int result =await _unitOfWork.CommitAsync();
                return new ServiceResponse<bool>() {Success=result>0, Data=result>0,Message=  CultureHelper.GetResourceMessage(Resource.ResourceManager,result>0? nameof(Resource.Updated) : nameof(Resource.NotUpdated)) };
            }
            catch (Exception ex)
            {
                return await LogError<bool>(ex, false);
            }
        }
    }
} 