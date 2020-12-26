using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.DataModel
{
    public class ShortUrlContext : DbContext
    {
        public DbSet<UrlInfo> UrlInfoSet { get; set; }

        readonly string ConnString;

        public ShortUrlContext(string connString)
        {
            ConnString = connString;    
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnString);
        }
    }
}
