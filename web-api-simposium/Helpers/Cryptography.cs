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
    }
}
