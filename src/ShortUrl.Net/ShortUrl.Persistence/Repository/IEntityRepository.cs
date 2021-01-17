using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Persistence.Repository
{
    public interface IEntityRepository<T> where T: class
    {
        Task<T> GetAsync(object id);
        Task<T> InsertOrUpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
