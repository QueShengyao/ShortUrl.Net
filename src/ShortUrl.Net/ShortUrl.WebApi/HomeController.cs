using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Service;

namespace ShortUrl.WebApi
{
    public class HomeController : Controller
    {
        private readonly IShortUrlService _shortUrlService;

        public HomeController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        public async Task<IActionResult> ShortUrlRedirect(int id)
        {
            var url = await _shortUrlService.RetrieveUrlAsync(id);
            return Redirect(url);
        }
    }
}
