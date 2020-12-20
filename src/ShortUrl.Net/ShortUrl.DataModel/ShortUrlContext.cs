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

        public readonly IConfiguration Configuration;

        public ShortUrlContext(IConfiguration configuration)
        {
            Configuration = configuration;    
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = Configuration.GetConnectionString("ShortUrl");
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
