using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;

namespace Lost.Service.Common
{
    public interface ILostService
    {
        Task<ILostPerson> FindByIdAsync(Guid id);
        Task<IEnumerable<ILostPerson>> GetAllLostPersons();
        Task<int> ReportLostPerson(ILostPerson lp);
        Task<int> UpdateLostPerson(ILostPerson lp);
        Task<int> DeleteMissingPerson(ILostPerson lp);
    }
}
