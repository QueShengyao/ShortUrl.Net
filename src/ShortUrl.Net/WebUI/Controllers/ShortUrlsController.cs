using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.DataModel.DataContract;
using ShortUrl.Service;

namespace WebUI.Controllers
{
    [ApiController]
    public class ShortUrlsController : ControllerBase
    {
        private readonly IShortUrlService _shortUrlService;

        public ShortUrlsController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        [HttpPost("api/shorturls")]
        public async Task<ActionResult<ShortUrlDC>> CreateAsync([FromBody] ShortUrlParameter parameter)
        {
            try
            {
                var result = await _shortUrlService.GenerateUrlAsync(parameter?.OriginalUrl);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid URL",
                    Detail = ex.Message
                });
            }
        }

        [HttpGet("api/shorturls")]
        public async Task<ActionResult<IReadOnlyCollection<ShortUrlDC>>> GetRecentAsync([FromQuery] int count = 10)
        {
            var result = await _shortUrlService.GetRecentUrlsAsync(count);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> RedirectAsync(int id)
        {
            var url = await _shortUrlService.RetrieveUrlAsync(id);

            if (string.IsNullOrWhiteSpace(url))
            {
                return NotFound();
            }

            return Redirect(url);
        }
    }
}
