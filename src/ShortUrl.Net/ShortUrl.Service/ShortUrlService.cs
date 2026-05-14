using System;
using System.Collections.Generic;
using System.Linq;
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

    public interface IShortUrlRetrieve
    {
        Task<string> RetrieveUrlAsync(int id);
    }

    public interface IShortUrlReporter
    {
        Task<IReadOnlyCollection<ShortUrlDC>> GetRecentUrlsAsync(int count);
    }

    public interface IShortUrlService : IShortUrlGenerator, IShortUrlRetrieve, IShortUrlReporter
    {

    }

    public class ShortUrlService : IShortUrlService
    {
        private readonly IUrlInfoRepository _urlRepo;
        public ShortUrlService(IUrlInfoRepository urlRepo)
        {
            _urlRepo = urlRepo;
        }

        #region  IShortUrlGenerator
        public async Task<ShortUrlDC> GenerateUrlAsync(string originalUrl)
        {
            if (!TryNormalizeUrl(originalUrl, out var normalizedUrl))
            {
                throw new ArgumentException("Please enter a valid absolute HTTP or HTTPS URL.", nameof(originalUrl));
            }

            var newInfo = new UrlInfo()
            {
                Url = normalizedUrl,
                CreatedDate = DateTime.UtcNow
            };
            await _urlRepo.InsertOrUpdateAsync(newInfo);
            var inserted = await _urlRepo.GetAsync(newInfo.Id);
            return new ShortUrlDC(inserted);
        }
        #endregion

        #region IShortUrlRetrieve

        public async Task<string> RetrieveUrlAsync(int id)
        {
            var info = await _urlRepo.GetAsync(id);
            return info?.Url;
        }

        #endregion

        public async Task<IReadOnlyCollection<ShortUrlDC>> GetRecentUrlsAsync(int count)
        {
            var sanitizedCount = Math.Min(Math.Max(count, 1), 50);
            var infos = await _urlRepo.GetRecentAsync(sanitizedCount);
            return infos.Select(item => new ShortUrlDC(item)).ToList();
        }

        private static bool TryNormalizeUrl(string originalUrl, out string normalizedUrl)
        {
            normalizedUrl = null;

            if (string.IsNullOrWhiteSpace(originalUrl))
            {
                return false;
            }

            if (!Uri.TryCreate(originalUrl.Trim(), UriKind.Absolute, out var uri))
            {
                return false;
            }

            if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
            {
                return false;
            }

            normalizedUrl = uri.AbsoluteUri;
            return true;
        }
    }
}
