using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface ITokenService
    {
        public Task<string> CreateToken(AppUser appUser);

        ClaimsPrincipal ValidateToken(string token);

    }
};