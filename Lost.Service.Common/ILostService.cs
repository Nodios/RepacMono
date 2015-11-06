using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;
using Lost.Model;

namespace Lost.Service.Common
{
    public interface ILostService
    {
        IEnumerable<LostPersonEntity> GetAllMissingPersons();
        IEnumerable<LostPersonEntity> GetLostPersonIncludingRedCross();

        #region not used
        /*
        IEnumerable<ILostPerson> GetByLocation(string location);
        ICollection<ILostPerson> GetByCountry(string country);
        ICollection<ILostPerson> GetByReportDate(DateTime reportDate);
        ICollection<ILostPerson> GetByDateLastSeen(DateTime lastSeen);
        ICollection<ILostPerson> GetByLocationLastSeen(string lastSeen);
        */
        #endregion

        bool ReportMissingPerson(LostPersonEntity lpe);
        void UpdateMissingPerson(LostPersonEntity lpe);
        void DeleteMissingPerson(int id);
        LostPersonEntity GetMissingPersonById(int? id);
        void SaveMissingPerson();
    }
}
