using ShortUrl.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Persistence.Repository
{
    public interface IUrlInfoRepository: IEntityRepository<UrlInfo>
    {
    }
}
