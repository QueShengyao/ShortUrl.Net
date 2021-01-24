using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ShortUrl.Persistence.Repository
{
    public class UrlInfoRepository : IUrlInfoRepository
    {
        private readonly ShortUrlContext _context;

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
