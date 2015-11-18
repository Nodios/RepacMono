using Lost.DAL;
using Lost.Repository.Common;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lost.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ISearchContext Context { get; private set; }

        public UnitOfWork(ISearchContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context is null");
            }
            Context = context;
        }

        public Task<T> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntity = Context.Entry(entity);
                if (dbEntity.State != EntityState.Detached)
                {
                    dbEntity.State = EntityState.Added;
                }
                else
                {
                    Context.Set<T>().Add(entity);
                }
                return Task.FromResult(dbEntity.Entity as T);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Task<T> Update<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry<T>(entity);
                entry.State = EntityState.Modified;

                return Task.FromResult(entry.Entity as T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry(entity);
                if (entry.State != EntityState.Deleted)
                {
                    entry.State = EntityState.Deleted;
                }
                return Task.FromResult(1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> DeleteAsync<T>(int id) where T : class
        {
            try
            {
                T entity = Context.Set<T>().Find(id);
                if (entity == null)
                {
                    return Task.FromResult(0);
                }
                return DeleteAsync<T>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> DeleteAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> match) where T : class
        {
            try
            {
                T entity = Context.Set<T>().Where(match).First();
                if (entity == null)
                {
                    return Task.FromResult(0);
                }
                return DeleteAsync<T>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
