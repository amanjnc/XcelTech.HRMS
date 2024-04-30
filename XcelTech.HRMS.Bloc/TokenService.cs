using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc
{
    public class TokenService : ITokeNService
    {


        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public string CreateToken(AppUser appUser)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.GivenName, appUser.UserName),
                new Claim(JwtRegisteredClaimNames.Email, appUser.Email)
            };

            var Creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = Creds,
                Issuer = _config["JWT:Audience"],
                Audience = _config["JWT:Audience"]

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
    }
}
