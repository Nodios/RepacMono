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
    public class LostRepository : GenericRepository<ILostPerson>, ILostRepository
    {
        public LostRepository(SearchContext context)
            : base(context)
        {

        }
        public ILostPerson GetById(int id)
        {
            return dbSet.Include(x => x.IsFound == true).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
