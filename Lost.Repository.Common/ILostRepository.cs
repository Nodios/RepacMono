using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;
using Lost.Common.Filters;
using System.Linq.Expressions;

namespace Lost.Repository.Common
{
    public interface ILostRepository
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ILostPerson> GetAsync(Guid id);
        /// <summary>
        /// Get all lost person from red cross
        /// </summary>
        /// <param name="redCrossId"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<ILostPerson>> GetAllAsync(Guid redCrossId, LostPersonFilter filter = null);
        /// <summary>
        /// Get all lost persons
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        Task<IEnumerable<ILostPerson>> GetEveryoneAsync(LostPersonFilter filter = null);

        Task<int> AddAsync(ILostPerson lp);
        Task<int> UpdateAsync(ILostPerson lp);
        Task<int> DeleteAsync(ILostPerson lp);
        Task<int> DeleteAsync(params Guid[] id);
    }
}
