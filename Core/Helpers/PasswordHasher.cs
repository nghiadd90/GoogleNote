using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using GoogleNote.Core.Models;

namespace GoogleNote.Core.Helpers
{
    public class PasswordHasher
    {
        public static string HashPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)
            );
        }

        public static bool VerifyPassword(User user, string password)
        {
            return HashPassword(password, Convert.FromBase64String(user.PasswordSalt)) == user.Password;
        }

        public static byte[] SaltGenerator()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            
            return salt;
        }
    }
}
