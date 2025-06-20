using UrlShortener.Models;

namespace UrlShortener.Services
{
    public interface IUrlService
    {
        UrlResponse ShortenUrl(string longUrl);
        string? GetLongUrl(string key);
        bool DeleteUrl(string key);
    }
}
