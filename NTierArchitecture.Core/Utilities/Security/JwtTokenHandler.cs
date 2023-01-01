using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Utilities.Security
{
    public class JwtTokenHandler : ITokenHandler
    {
        private readonly JwtOptions _jwtOptions;

        public JwtTokenHandler(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string CreateToken()
        {
            var claims = new Claim[]{
                new Claim(JwtRegisteredClaimNames.Sub,"Taner Saydam"),
                new Claim(JwtRegisteredClaimNames.Email, "tanersaydam@gmail.com")
            };

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
