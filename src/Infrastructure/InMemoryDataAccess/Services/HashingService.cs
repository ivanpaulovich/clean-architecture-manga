// adapted from:
// https://codinginfinite.com/c-sharp-hashing-algorithm-class-asp-net-core/

namespace Infrastructure.InMemoryDataAccess.Services
{
    using System;
    using System.Security.Cryptography;
    using Application.Services;
    using Domain.ValueObjects;

    public class HashingService : IHashingService
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const string HashPrefix = "$MYHASH$V1$";

        public Password Hash(string password, int iterations = 10000)
        {
            // create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            // create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            // combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // convert to base64
            string base64Hash = Convert.ToBase64String(hashBytes);

            // format hash with extra information
            string rawPassword = $"{HashPrefix}{iterations}${base64Hash}";
            return new Password(rawPassword);
        }

        public bool IsHashSupported(string hashString)
            => hashString.Contains(HashPrefix);

        public bool Verify(string password, string hashedPassword)
        {
            // check hash
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            // extract iteration and Base64 string
            var splittedHashString = hashedPassword
                .Replace(HashPrefix, string.Empty)
                .Split('$');
            int iterations = int.Parse(splittedHashString[0]);
            string base64Hash = splittedHashString[1];

            // get hash bytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            // get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // get result
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
