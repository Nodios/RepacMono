using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.DAL;
using Lost.Model.Common;

namespace Lost.Repository.Common
{
    public interface IRedRepository
    {
        Task<IRedCross> GetAsync(Guid id);
        Task<IEnumerable<IRedCross>> GetAsync();

        Task<int> AddAsync(IRedCross rc);
        Task<int> UpdateAsync(IRedCross rc);
        Task<int> DeleteAsync(IRedCross rc);
        Task<int> DeleteAsync(Guid id);
    }
}
