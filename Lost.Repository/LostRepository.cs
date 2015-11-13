using System;
using System.Collections.Generic;
using System.Linq;
using Lost.DAL;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Lost.Repository
{
    public class LostRepository : GenericRepository<LostPersonEntity>, ILostRepository
    {
        public LostRepository(SearchContext context)
            : base(context)
        {
        }
        public IQueryable<LostPersonEntity> GetById(int id)
        {
            var query = dbSet.Where(x => x.Id == id);
            return query;
        }
    }
}
