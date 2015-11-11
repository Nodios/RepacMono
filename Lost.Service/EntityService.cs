using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Service.Common;
using Lost.Repository.Common;

namespace Lost.Service
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        IUnitOfWork unitOfWork;
        IGenericRepository<T> repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            repository.Add(entity);
            unitOfWork.Commit();
        }
        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            repository.Update(entity);
            unitOfWork.Commit();
        }
        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");
            repository.Delete(entity);
            unitOfWork.Commit();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }
    }
}
