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
        IEnumerable<ILostPerson> GetAllMissingPersons();
        IEnumerable<ILostPerson> GetByLocation(string location);
        IEnumerable<ILostPerson> GetByCountry(string country);
        IEnumerable<ILostPerson> GetByReportDate(DateTime reportDate);
        IEnumerable<ILostPerson> GetByDateLastSeen(DateTime lastSeen);
        IEnumerable<ILostPerson> GetByLocationLastSeen(string lastSeen);

        bool ReportMissingPerson(LostPersonEntity lpe);
        void UpdateMissingPerson(LostPersonEntity lpe);
        void DeleteMissingPerson(int id);
        void SaveMissingPerson();
    }
}
