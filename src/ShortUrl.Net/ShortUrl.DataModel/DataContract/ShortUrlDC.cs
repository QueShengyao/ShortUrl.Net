using System;

namespace ShortUrl.DataModel.DataContract
{
    public class ShortUrlDC
    {
        public string ShortUrl { get; set; }
        public string OriginalUrl { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
