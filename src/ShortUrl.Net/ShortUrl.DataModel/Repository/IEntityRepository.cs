using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Persistence.Repository
{
    public interface IEntityRepository<T> where T: class
    {
        T Get(object id);
        T InsertOrUpdate(T entity);
        void Delete(object id);
    }
}
