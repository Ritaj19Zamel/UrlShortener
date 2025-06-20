namespace UrlShortener.Services
{
    public interface IKeyGenerator
    {
        string GenerateKey(string input);
    }
}
