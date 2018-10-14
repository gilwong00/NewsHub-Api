using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace NewsHubApi.Services
{
    public class PasswordService : IPasswordService
    {
        /// <summary>
        /// Size of salt
        /// </summary>
        private const int SaltSize = 16;

        /// <summary>
        /// Size of hash
        /// </summary>
        private const int HashSize = 20;

        public string HashUserPassword(string password)
        {
            //create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            //create hash for password
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            var hash = pbkdf2.GetBytes(HashSize);

            //combine salt and hash together into hashbytes
            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //create hashed password
            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }

        public bool ValidatePassword(string enteredPassword, string savedHashedPassword)
        {
            var hashBytes = Convert.FromBase64String(savedHashedPassword);

            /* Get the salt */
            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 1000);
            var hash = pbkdf2.GetBytes(20);

            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}