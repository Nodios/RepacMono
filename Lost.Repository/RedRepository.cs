using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.DAL;
using Lost.Repository.Common;
using Lost.Model.Common;
using Lost.Model;

namespace Lost.Repository
{
    public class RedRepository : GenericRepository<RedCrossEntity>, IRedRepository
    {
        public RedRepository(SearchContext context)
            : base(context)
        {
        }
        public RedCrossEntity GetById(int id)
        {
            var query = dbSet.Where(x => x.Id == id).FirstOrDefault();
            return query;
        }
    }
}
