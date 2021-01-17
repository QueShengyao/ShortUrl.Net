using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Persistence
{
    public class ShortUrlContext : DbContext
    {
        public DbSet<UrlInfo> UrlInfoSet { get; set; }

        private readonly string _connString;
        public ShortUrlContext(string connString)
        {
            _connString = connString;    
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }
    }
}
