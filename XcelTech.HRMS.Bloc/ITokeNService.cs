using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc
{
    public interface ITokeNService
    {
        string CreateToken(AppUser appUser);

    }
}