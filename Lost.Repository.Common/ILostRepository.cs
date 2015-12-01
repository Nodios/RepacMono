using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;
using Lost.Common;
using System.Linq.Expressions;

namespace Lost.Repository.Common
{
    public interface ILostRepository
    {
        Task<ILostPerson> GetAsync(Guid id);
        Task<IEnumerable<ILostPerson>> GetAllAsync(Guid redCrossId/*, Paging paging = null*/);
        Task<IEnumerable<ILostPerson>> GetEveryoneAsync(/*Paging paging = null*/);
        Task<int> AddAsync(ILostPerson lp);
        Task<int> UpdateAsync(ILostPerson lp);
        Task<int> DeleteAsync(ILostPerson lp);
        Task<int> DeleteAsync(params Guid[] id);
    }
}
