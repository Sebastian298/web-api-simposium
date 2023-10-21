using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace web_api_simposium.Helpers
{
    public static class Cryptography
    {
        public static string ConvertToHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static string GetUserIdByJwt(string authorizationHeader)
        {
            if (authorizationHeader != null)
            {
                var token = authorizationHeader.Substring(7);

                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(token) as JwtSecurityToken;
                return tokenS.Claims.FirstOrDefault(claim => claim.Type == "userId").Value;
            }
            return "";
        }
    }
}
