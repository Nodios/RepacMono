using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.Repository.Common;
using Lost.Service.Common;
using Lost.DAL;

namespace Lost.Service
{
    public class RedService : IRedService
    {
        private readonly IRedRepository Repository;

        public RedService(IRedRepository repository)
        {
            Repository = repository;
            if (Repository == null) throw new ArgumentNullException("Repository is null. Must be IRedRepository");
        }

        public Task<IRedCross> GetByIdAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        public Task<IEnumerable<IRedCross>> GetAllAsync(/*Lost.Common.Paging paging*/)
        {
            return Repository.GetAsync(/*paging*/);
        }

        public Task<int> AddAsync(IRedCross rc)
        {
            return Repository.AddAsync(rc);
        }

        public Task<int> UpdateAsync(IRedCross rc)
        {
            return Repository.UpdateAsync(rc);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }
    }
}
