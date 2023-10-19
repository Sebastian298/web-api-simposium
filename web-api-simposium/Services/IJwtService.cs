using Microsoft.IdentityModel.Tokens;
using web_api_simposium.Models.Authentications;

namespace web_api_simposium.Services
{
    public interface IJwtService
    {
        SecurityToken GenerateToken(TokenData tokenData, string secretKeyId);
        TokenData ValidateToken(string token, string secretKeyId);
    }
}
