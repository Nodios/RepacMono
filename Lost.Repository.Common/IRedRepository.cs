using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.DAL;
using Lost.Model.Common;

namespace Lost.Repository.Common
{
    public interface IRedRepository : IGenericRepository<RedCrossEntity>
    {
        RedCrossEntity GetById(int id);
    }
}
