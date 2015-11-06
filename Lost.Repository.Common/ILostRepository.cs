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
        IQueryable<LostPersonEntity> GetAllWithRedCross();

        #region not used
        /*
        IEnumerable<ILostPerson> GetByLocation(string location);
        ICollection<ILostPerson> GetByCountry(string country);
        ICollection<ILostPerson> GetByReportDate(DateTime reportDate);
        ICollection<ILostPerson> GetByDateLastSeen(DateTime lastSeen);
        ICollection<ILostPerson> GetByLocationLastSeen(string lastSeen);
        */
        #endregion
    }
}
