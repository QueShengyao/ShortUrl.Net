using System;

namespace ShortUrl.Persistence
{
    public class UrlInfo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
