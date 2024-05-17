using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;

        public TokenService(IConfiguration config, UserManager<AppUser> userManager)
        {
            _config = config;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public async Task<string> CreateToken(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, appUser.UserName),
                new Claim(JwtRegisteredClaimNames.Email, appUser.Email)
            };

            var userRoles = await _userManager.GetRolesAsync(appUser);
            //just assuming  user having multiple roles, currntly i dont.
            foreach (var userRole in userRoles)
            {
                Console.WriteLine(userRole);
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }



            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _key,
                ValidateIssuer = true,
                ValidIssuer = _config["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = _config["JWT:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (Exception)
            {
                // Token validation failed
                return null;
            }
        }
    }
}