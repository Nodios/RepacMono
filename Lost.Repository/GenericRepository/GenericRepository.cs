using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Repository.Common;
using Lost.DAL;
using Lost.Model.Common;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace Lost.Repository
{
    public class GenericRepository : IGenericRepository
    {
        protected ISearchContext Context { get; private set; }
        protected IUnitOfWorkFactory UoWFac { get; private set; }

        public GenericRepository(ISearchContext context, IUnitOfWorkFactory uoWFac)
        {
            if (context == null) throw new ArgumentNullException("context is null");

            this.Context = context;
            this.UoWFac = uoWFac;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return UoWFac.CreateUnitOfWork();
        }
        /// <summary>
        /// Fetch single entity
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="id">entity id</param>
        /// <returns>entity or null</returns>
        public Task<T> GetAsync<T>(Guid id) where T : class
        {
            return Context.Set<T>().FindAsync(id);
        }
        /// <summary>
        /// Get where
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        public IQueryable<T> Where<T>() where T : class
        {
            return Context.Set<T>();
        }
        /// <summary>
        /// Find entity by match
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="match">expression</param>
        /// <returns>entity or null</returns>
        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().FirstAsync(match);
        }
        /// <summary>
        /// Find entities
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="match">expression</param>
        /// <returns>list of T entities or null</returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().Where(match).ToListAsync();
        }
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <returns>list of T entities or null</returns>
        public async Task<IEnumerable<T>> GetEverything<T>() where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }


        //ADD, UPDATE, DELETE
        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                Context.Set<T>().Add(entity);
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached) Context.Set<T>().Attach(entity); //.Detached - the entity is not being tracked by the context: https://msdn.microsoft.com/en-us/data/jj592676.aspx
            entry.State = EntityState.Modified; //The entity is being tracked by the context and exists in the database, and some or all of its property values have been modified
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Deletes entity
        /// </summary>
        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                Context.Set<T>().Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Deletes entity
        /// </summary>
        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            T entity = await GetAsync<T>(id); //dohvati entity sa id
            if (entity == null) throw new ArgumentNullException("entity is null, does not exist");
            return await DeleteAsync<T>(entity); //call delete method above and delete entity with id id
        }
    }
}
