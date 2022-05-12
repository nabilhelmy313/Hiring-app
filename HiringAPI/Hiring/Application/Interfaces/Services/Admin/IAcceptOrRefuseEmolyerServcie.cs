using Domain.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Admin
{
    public interface IAcceptOrRefuseEmolyerServcie 
    {
        Task<ServiceResponse<List<GetEmployerInfoDto>>> GetEmployers(string RoleName);
        Task<ServiceResponse<bool>> UpdateActivationOfUser(string UserId);
    }
}
