using System;
using ShortUrl.DataModel.DataContract;

namespace ShortUrl.Service
{
    public interface IShortUrlGenerator
    {
        ShortUrlDC GenerateUrl(string originalUrl);
    }

    public class ShortUrlService : IShortUrlGenerator
    {
        
        public ShortUrlDC GenerateUrl(string originalUrl)
        {
            throw new NotImplementedException();
        }
    }
}
