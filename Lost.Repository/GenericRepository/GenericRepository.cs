using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Repository.Common;
using Lost.DAL;
using Lost.Model.Common;
using System.Data.Entity;

namespace Lost.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected SearchContext Context;
        protected readonly IDbSet<T> dbSet;
        public GenericRepository(SearchContext context)
        {
            Context = context;
            dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable<T>();
        }
        public virtual IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = dbSet.Where(predicate).AsEnumerable();
            return query;
        }
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }
        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
