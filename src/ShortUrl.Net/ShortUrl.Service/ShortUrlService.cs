using System;
using System.Threading.Tasks;
using ShortUrl.DataModel.DataContract;
using ShortUrl.Persistence;
using ShortUrl.Persistence.Repository;

namespace ShortUrl.Service
{
    public interface IShortUrlGenerator
    {
        Task<ShortUrlDC> GenerateUrlAsync(string originalUrl);
    }

    public class ShortUrlService : IShortUrlGenerator
    {
        private readonly IUrlInfoRepository _urlRepo;
        public ShortUrlService(IUrlInfoRepository urlRepo)
        {
            _urlRepo = urlRepo;
        }

        public async Task<ShortUrlDC> GenerateUrlAsync(string originalUrl)
        {
            var newInfo = new UrlInfo()
            {
                Url = originalUrl,
                CreatedDate = DateTime.UtcNow
            };
            await _urlRepo.InsertOrUpdateAsync(newInfo);
            var inserted = await _urlRepo.GetAsync(newInfo.Id);
            return new ShortUrlDC(inserted);
        }
    }
}
