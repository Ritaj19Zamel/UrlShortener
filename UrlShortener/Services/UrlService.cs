using UrlShortener.Models;

namespace UrlShortener.Services
{
    public class UrlService : IUrlService
    {
        private static readonly Dictionary<string, string> urlMap = new(); //key --> longUrl
        private static readonly Dictionary<string, string> reverseMap = new(); //longUrl --> key
        private readonly IKeyGenerator _keyGenerator;
        public UrlService(IKeyGenerator keyGenerator)
        {
            _keyGenerator = keyGenerator;
        }
        public bool DeleteUrl(string key)
        {
            if (!urlMap.TryGetValue(key, out var longUrl)) return false;
            urlMap.Remove(key);
            reverseMap.Remove(longUrl);
            return true;
        }

        public string? GetLongUrl(string key)
        {
            return urlMap.TryGetValue(key, out var longUrl) ? longUrl : null;
        }

        public UrlResponse ShortenUrl(string longUrl)
        {
            if(reverseMap.TryGetValue(longUrl, out var existingKey))
            {
                return new UrlResponse
                {
                    Key = existingKey,
                    LongUrl = longUrl,
                    ShortUrl = $"http://localhost/{existingKey}"
                };
            }
            var key = _keyGenerator.GenerateKey(longUrl);
            while (urlMap.ContainsKey(key) && urlMap[key] != longUrl)
            {
                key = _keyGenerator.GenerateKey(longUrl);
                
            }
            urlMap[key] = longUrl;
            reverseMap[longUrl] = key;
            return new UrlResponse
            {
                Key= key,
                LongUrl = longUrl,
                ShortUrl = $"http://localhost/{key}"
            };
        }
    }
}
