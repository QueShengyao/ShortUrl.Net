using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortUrl.DataModel.DataContract;
using ShortUrl.Persistence;
using ShortUrl.Persistence.Repository;
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
        [HttpPut("{id}")]
        public async Task<ShortUrlDC> PutUrlInfo(ShortUrlDC urlInfo)
        {
            var result = await _suService.GenerateUrlAsync(urlInfo.OriginalUrl);
            return result;
        }
    }
}
