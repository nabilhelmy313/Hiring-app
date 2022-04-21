﻿
using Domain.Dto.General.Auth;
using Domain.Entities.General;



namespace Application.Interfaces.Services.General
{
    public interface IUserService
    {
        Task<ServiceResponse<TokenDto>> Token(LoginDto loginDto );
        //Task<ServiceResponse<ApplicationUser>> RegisterAccounUser(AddAspNetUserDto registerAccountUserDto, List<string> Roles, bool isEstablishUser = false);
        //Task DeletAccountUser(string userName);
        //Task<ServiceResponse<ApplicationUser>> EditAccountUser(EditAspNetUserDto editAccountUserDto, List<string> Roles);
        //Task<ServiceResponse<List<GhadanEmployeeRoleDto>>> GetUserRoles(string employeeId);
        //Task<ServiceResponse<Boolean>> CheckOldPassword(string Password, string UserId);
        //Task<ServiceResponse<Array>> Resetpassword(string Newpassword, string UserId);
        //Task<ServiceResponse<ApplicationUser>> ChangeRolesToUserId(string userId, string Role);

        //Task<ServiceResponse<int>> ToggleActiveUser(string userId);
        //Task<ServiceResponse<Array>> ForgetPassword(ForgetPasswordDto forgetPasswordDto);
        //Task<ServiceResponse<Array>> ResetpasswordForAnonymousUser(RestPasswordForAnonymousUserDto restPasswordForAnonymousUserDto);

    }
}
