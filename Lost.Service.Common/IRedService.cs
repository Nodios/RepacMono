using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;

namespace Lost.Service.Common
{
    public interface IRedService : IEntityService<RedCrossEntity>
    {
        IEnumerable<RedCrossEntity> GetById(int id);
        IEnumerable<RedCrossEntity> GetByCountry(string country);
    }
}
