using ShortUrl.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShortUrl.Persistence.Repository
{
    class UrlInfoRepository : IUrlInfoRepository
    {
        private  ShortUrlContext _context;

        public UrlInfoRepository(ShortUrlContext context)
        {
            _context = context;
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public UrlInfo Get(object id)
        {
            throw new NotImplementedException();
        }

        public UrlInfo InsertOrUpdate(UrlInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
