using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web_api_simposium.Models.Authentications;

namespace web_api_simposium.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SecurityToken GenerateToken(TokenData tokenData, string secretKeyId)
        {
            var authClaims = new List<Claim>
            {
               new Claim("userId", tokenData.UserId)
            };

            var key = Encoding.ASCII.GetBytes(_configuration[$"authenticationSettings:jwt:{secretKeyId}"]);

            var token = new JwtSecurityTokenHandler().CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.UtcNow
            });

            return token;
        }
    }
}
