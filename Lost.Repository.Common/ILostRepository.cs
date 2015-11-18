using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;
using System.Linq.Expressions;

namespace Lost.Repository.Common
{
    public interface ILostRepository
    {
        Task<ILostPerson> GetAsync(int id);
        Task<IEnumerable<ILostPerson>> GetAllAsync(int redCrossId);
        Task<IEnumerable<ILostPerson>> GetEveryoneAsync();

        Task<int> AddAsync(ILostPerson lp);
        Task<int> UpdateAsync(ILostPerson lp);
        Task<int> DeleteAsync(ILostPerson lp);
        Task<int> DeleteAsync(params int[] id);
    }
}
