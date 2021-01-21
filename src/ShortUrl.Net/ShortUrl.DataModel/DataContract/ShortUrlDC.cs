using System;
using ShortUrl.Persistence;

namespace ShortUrl.DataModel.DataContract
{
    public class ShortUrlDC
    {
        public string ShortUrl { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime CreatedTime { get; set; }

        public ShortUrlDC() { }

        public ShortUrlDC(UrlInfo shortUrl)
        {
            ShortUrl = shortUrl.Id.ToString();
            OriginalUrl = shortUrl.Url;
            CreatedTime = shortUrl.CreatedDate;
        }
    }
}
