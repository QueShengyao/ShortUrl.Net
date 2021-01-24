using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.DataModel.DataContract;
using ShortUrl.Service;

namespace ShortUrl.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlInfoController : ControllerBase
    {
        private readonly IShortUrlService _suService;

        public UrlInfoController(IShortUrlService service)
        {
            _suService = service;
        }

        // GET: api/UrlInfo
        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortUrlDC>>> GetUrlInfoSet()
        {
            return await _context.UrlInfoSet.AsNoTracking().ToListAsync();
        }
        */

        /*
        // GET: api/UrlInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortUrlDC>> GetUrlInfo(int id)
        {
            var urlInfo = await _context.UrlInfoSet.FindAsync(id);

            if (urlInfo == null)
            {
                return NotFound();
            }

            return urlInfo;
        }
        */

        // PUT: api/UrlInfo
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ShortUrlDC> PutUrlInfo(ShortUrlParameter parameter)
        {
            var result = await _suService.GenerateUrlAsync(parameter.OriginalUrl);
            return result;
        }
    }
}
