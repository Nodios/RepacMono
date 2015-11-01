using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lost.DAL;
using System.Data.Entity;
using Lost.Repository.Common;

namespace Lost.Repository
{
    public class EntityBase<T> : IEntityBase<T> where T : class
    {
        private SearchContext Context { get; set; }
        protected IDbSet<T> _dbSet { get; set; }

        public EntityBase(SearchContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            else
            {
                Context = context;
                _dbSet = Context.Set<T>();
            }
        }

        //New entity
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            Context.SaveChanges();
        }
        //Update entity
        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        //Delete entity
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Context.SaveChanges();
        }
        //Get by ID
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        //Get all
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
