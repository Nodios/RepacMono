using Lost.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Service.Common
{
    public interface IPersonInChargeService
    {
        Task<IPersonInCharge> GetAsync(string id);
        Task<IPersonInCharge> GetCurrentAsync();
        Task<int> AddAsync(IPersonInCharge pic);
        Task<int> UpdateAsync(IPersonInCharge pic);
        Task<int> DeleteAsync(IPersonInCharge pic);
    }
}
