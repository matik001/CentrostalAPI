using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.Helpers {
    public static class HashingHelper {
        public static string hashUsingPbkdf2(string password, string salt) {
            using var bytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256);
            var derivedRandomKey = bytes.GetBytes(32);
            var hash = Convert.ToBase64String(derivedRandomKey);
            return hash;
        }

        public static string genSalt(int maximumSaltLength = 32) {
            var salt = new byte[maximumSaltLength];
            using var random = new RNGCryptoServiceProvider();
            random.GetNonZeroBytes(salt);

            return Convert.ToBase64String(salt);
        }
    }
}
