using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.DataModel
{
    public class ShortUrlContext : DbContext
    {
        public DbSet<UrlInfo> UrlInfoSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();
    }
}
