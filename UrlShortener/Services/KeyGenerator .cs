using System;
using System.Security.Cryptography;
using System.Text;

namespace UrlShortener.Services
{
    public class KeyGenerator : IKeyGenerator
    {
        public string GenerateKey(string url)
        {
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(url));
            return Convert.ToBase64String(hash)
                .Replace("/", "").Replace("+", "").Substring(0, 6);

        }
    }
}
