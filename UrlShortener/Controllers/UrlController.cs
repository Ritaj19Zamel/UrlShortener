using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }
        [HttpPost("shorten")]
        public IActionResult ShortenUrl([FromBody] UrlRequest request)
        {
            if(string.IsNullOrEmpty(request.Url))
            {
                if (string.IsNullOrWhiteSpace(request.Url))
                    return BadRequest("Missing field: url");
            }
            var result = _urlService.ShortenUrl(request.Url);
            return Ok(result);
        }
        [HttpGet("{key}")]
        public IActionResult RedirectToLongUrl(string key)
        {
            var longUrl = _urlService.GetLongUrl(key);
            return longUrl == null ? NotFound("URL not found") : Redirect(longUrl);
        }
        [HttpDelete("{key}")]
        public IActionResult DeleteUrl(string key)
        {
            if (_urlService.DeleteUrl(key))
            {
                return Ok("URL deleted successfully");
            }
            return NotFound("URL not found");
        }

    }
}
