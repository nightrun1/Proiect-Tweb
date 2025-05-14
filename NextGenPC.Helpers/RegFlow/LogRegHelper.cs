using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NextGenPC.Helpers.RegFlow
{
    public class LogRegHelper
    {
        public static string GenerateSecureToken(int userId)
        {
             string  _secretKey = "your_secret_key"; //mb make him private readonly?
            string tokenData = $"{userId}:{DateTime.UtcNow.Ticks}";
            byte[] keyBytes = Encoding.UTF8.GetBytes(_secretKey);
            byte[] dataBytes = Encoding.UTF8.GetBytes(tokenData);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(dataBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
