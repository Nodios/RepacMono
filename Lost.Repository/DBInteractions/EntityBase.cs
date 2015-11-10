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
    public abstract class EntityBase<T, C> : IEntityBase<T> where T : class where C : DbContext, new(){
        private C context = new C();
        public C Context{
            get{return context;}
            set{context = value;}
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = context.Set<T>();
            return query;
        }
        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = context.Set<T>().Where(predicate);
            return query;
        }
        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Save()
        {
            context.SaveChanges();
        }
    }



    /*{
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
        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }
        //Get all
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }*/
}
