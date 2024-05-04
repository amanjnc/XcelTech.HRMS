using System.Security.Claims;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
        ClaimsPrincipal ValidateToken(string token);

    }
};