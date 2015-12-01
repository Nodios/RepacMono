using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;
using Lost.Common;

namespace Lost.Service.Common
{
    public interface IRedService
    {
        Task<IRedCross> GetByIdAsync(Guid id);
        Task<IEnumerable<IRedCross>> GetAllAsync(/*Paging paging*/);
        Task<int> AddAsync(IRedCross rc);
        Task<int> UpdateAsync(IRedCross rc);
        Task<int> DeleteAsync(Guid id);
    }
}
