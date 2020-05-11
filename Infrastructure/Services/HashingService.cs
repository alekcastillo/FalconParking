using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class HashingService
    {
        public HashingService() {}

        public string HashString(string salt, string password)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password,
               salt: saltBytes,
               prf: KeyDerivationPrf.HMACSHA1,
               iterationCount: 1000,
               numBytesRequested: 256 / 8));
        }

        public string GenerateSalt(int maxLength)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[maxLength];

            random.GetNonZeroBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }
    }
}
