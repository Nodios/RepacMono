using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;
using Lost.Common.Filters;

namespace Lost.Service.Common
{
    public interface ILostService
    {
        Task<ILostPerson> FindByIdAsync(Guid id);
        Task<IEnumerable<ILostPerson>> GetAllLostPersons(GenericFilter filter);
        Task<IEnumerable<ILostPerson>> GetFromRedCross(Guid id, GenericFilter filters);

        Task<int> ReportLostPerson(ILostPerson lp);
        Task<int> UpdateLostPerson(ILostPerson lp);
        Task<int> DeleteMissingPerson(Guid id);
    }
}
