using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;

namespace Lost.Repository.Common
{
    public interface ILostRepository
    {
        List<ILostPerson> GetAllLostPersons();
        List<ILostPerson> GetByLocation();
        List<ILostPerson> GetByCountry();
        List<ILostPerson> GetByReportDate();
        List<ILostPerson> GetByDateLastSeen();
        List<ILostPerson> GetByLocationLastSeen();

        //Import new lost person
        bool GetLostPersonById(int id);

    }
}
