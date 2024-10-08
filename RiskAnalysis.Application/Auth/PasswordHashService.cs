using System.Security.Cryptography;
using System.Text;

namespace RiskAnalysis.Application
{
    public interface IPasswordHashService : IApplicationService
    {
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash);
    }

    public class PasswordHashService : IPasswordHashService
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;
        private readonly byte[] Salt = Encoding.UTF8.GetBytes("qWfqPfxquHVSgOq!");

        public string HashPassword(string password)
        {
            var hash = new Rfc2898DeriveBytes(password, Salt, Iterations, HashAlgorithmName.SHA256);
            byte[] key = hash.GetBytes(KeySize);

            var hashBytes = new byte[SaltSize + KeySize];
            Array.Copy(Salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(key, 0, hashBytes, SaltSize, KeySize);

            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            Array.Copy(hashBytes, 0, Salt, 0, SaltSize);

            var hash = new Rfc2898DeriveBytes(enteredPassword, Salt, Iterations, HashAlgorithmName.SHA256);
            byte[] key = hash.GetBytes(KeySize);

            byte[] originalKey = new byte[KeySize];
            Array.Copy(hashBytes, SaltSize, originalKey, 0, KeySize);

            return key.SequenceEqual(originalKey);
        }
    }
}
