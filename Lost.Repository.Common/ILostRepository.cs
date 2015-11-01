using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;

namespace Lost.Repository.Common
{
    public interface ILostRepository : IEntityBase<LostPersonEntity>
    {
        IQueryable<ILostPerson> GetByLocation(string location);
        IQueryable<ILostPerson> GetByCountry(string country);
        IQueryable<ILostPerson> GetByReportDate(DateTime reportDate);
        IQueryable<ILostPerson> GetByDateLastSeen(DateTime lastSeen);
        IQueryable<ILostPerson> GetByLocationLastSeen(string lastSeen);
    }
}
