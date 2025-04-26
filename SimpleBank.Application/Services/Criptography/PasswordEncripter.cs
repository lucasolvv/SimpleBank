using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Identity.Core;

namespace SimpleBank.Application.Services.Criptography
{
    public class PasswordEncripter
    {
        public static string Encrypt(string password)
        {
            var encripter = new PasswordHasher<string>();
            var hashedPasswrod = encripter.HashPassword(null, password);

           

            return hashedPasswrod;
        }

        public static bool Decrypt(string password, string storedPassword)
        {
            var decripter = new PasswordHasher<string>();
            var result = decripter.VerifyHashedPassword(null, storedPassword, password);

            return result == PasswordVerificationResult.Success
                ? true
                : false;
        }
    }
}
