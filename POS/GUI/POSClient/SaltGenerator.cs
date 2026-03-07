using System;
using System.Security.Cryptography;
using System.Text;

namespace POSClient
{
    public class SaltGenerator
    {
        public string GenerateSalt()
        {
            int size = 16;
            using(var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[size];
                rng.GetBytes(saltBytes);
                return BitConverter.ToString(saltBytes).Replace("-", "").ToLower();
            }
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}