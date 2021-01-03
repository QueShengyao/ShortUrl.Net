using ShortUrl.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShortUrl.Persistence.Repository
{
    class UrlInfoRepository : IUrlInfoRepository
    {
        private  ShortUrlContext _context;

        public UrlInfoRepository(ShortUrlContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await GetAsync(id);
            _context.UrlInfoSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UrlInfo> GetAsync(object id)
        {
            return await _context.UrlInfoSet.AsNoTracking().FirstOrDefaultAsync(item => item.Id == (int)id);
        }

        public async Task<UrlInfo> InsertOrUpdateAsync(UrlInfo entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var updated = _context.Update(entity);
            await _context.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
