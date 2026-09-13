using System.Security.Cryptography;
using FinancialPortfolio.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace FinancialPortfolio.Infrastructure.Services
{
    public sealed class Pbkdf2PasswordHasher : IPasswordHasher<User>
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

        public string HashPassword(User user, string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            string[] parts = hashedPassword.Split('-');

            if (parts.Length != 2)
            {
                return PasswordVerificationResult.Failed;
            }

            try
            {
                byte[] hash = Convert.FromHexString(parts[0]);
                byte[] salt = Convert.FromHexString(parts[1]);

                var inputHash = Rfc2898DeriveBytes.Pbkdf2(providedPassword, salt, Iterations, Algorithm, HashSize);

                return CryptographicOperations.FixedTimeEquals(inputHash, hash)
                    ? PasswordVerificationResult.Success
                    : PasswordVerificationResult.Failed;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e); //TODO: Log it
                return PasswordVerificationResult.Failed;

            }
        }
    }
}
