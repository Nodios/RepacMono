using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;

namespace Lost.Service.Common
{
    public interface ILostService
    {
        List<ILostPerson> GetAllMissingPersons();
        List<ILostPerson> GetByLocation(string location);
        List<ILostPerson> GetByCountry(string country);
        List<ILostPerson> GetByReportDate(DateTime reportDate);
        List<ILostPerson> GetByDateLastSeen(DateTime lastSeen);
        List<ILostPerson> GetByLocationLastSeen(string lastSeen);
        ILostPerson GetLostPersonById(int id);

        bool ReportMissingPerson(int id);
        List<IRedCross> GetAllRedCrosses();
        bool RemoveMissingPerson(int id);
    }
}
