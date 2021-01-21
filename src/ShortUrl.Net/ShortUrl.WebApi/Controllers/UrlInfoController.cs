using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortUrl.Persistence;
using ShortUrl.Persistence.Repository;

namespace ShortUrl.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlInfoController : ControllerBase
    {
        private readonly ShortUrlContext _context;

        public UrlInfoController(IUrlInfoRepository context)
        {
            _context = context;
        }

        // GET: api/UrlInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortUrlDC>>> GetUrlInfoSet()
        {
            return await _context.UrlInfoSet.AsNoTracking().ToListAsync();
        }

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

        // PUT: api/UrlInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrlInfo(int id, ShortUrlDC urlInfo)
        {
            if (id != urlInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(urlInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrlInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UrlInfoExists(int id)
        {
            return _context.UrlInfoSet.AsNoTracking().Any(e => e.Id == id);
        }
    }
}
