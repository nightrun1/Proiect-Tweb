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
        private const string salt = "84de625db71b56d480d47bdc32377d23144b8c65";


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

        public static string HashPassword(string password)
        {
            string saltedPassword = $"{password}{salt}";

            using (var sha256 = SHA256.Create())
            {
                // Convertește parola în bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);

                // Calculează hash-ul
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convertește hash-ul în string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
