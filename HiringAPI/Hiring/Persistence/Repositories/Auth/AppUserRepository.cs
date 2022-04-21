using Application.Interfaces.Repositories.General.Auth;
using Domain.Entities.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Persistence.Repositories.Auth
{
    public class AppUserRepository: IAppUserRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly HiringDbContext _hiringDbContext;

        public AppUserRepository(UserManager<ApplicationUser> userManager, HiringDbContext HiringDbContext)
        {
            _userManager = userManager;
            _hiringDbContext = HiringDbContext;
        }

        public async Task<TokenEntity> GetToken(string userName, string password, string topSecretKey, string issuer, string audience)
        {
            try
            {
                ApplicationUser user = new();
                //var user = await _userManager.Users.Include(q => q.UserRoles).ThenInclude(q => q.Role).ThenInclude(q => q.RoleDepartment).Where(q => q.UserName == userName).FirstOrDefaultAsync();
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                    //new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    //new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
                };

                    var superSecretPassword = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(topSecretKey));

                    var token = new JwtSecurityToken(
                        issuer: issuer,
                        audience: audience,
                        expires: DateTime.Now.AddDays(1),
                        claims: claims,
                        signingCredentials: new SigningCredentials(superSecretPassword, SecurityAlgorithms.HmacSha256)
                    );

                    return new TokenEntity
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        CurrentUser = user,

                    };
                }
               
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
