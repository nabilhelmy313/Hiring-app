using Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.General.Auth
{
    public interface IAppUserRepository
    {
        Task<TokenEntity> GetToken(string userName, string password, string topSecretKey, string issuer, string audience);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task AddRoleToUser(ApplicationUser user, string Role);
         
    }
}
