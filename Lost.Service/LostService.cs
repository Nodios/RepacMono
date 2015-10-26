using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.Repository.Common;
using Lost.Service.Common;

namespace Lost.Service
{
    public class LostService : ILostService
    {
        public LostService(ILostRepository repository)
        {
            this.Repository = repository;
        }
        protected ILostRepository Repository { get; private set; }


        public List<ILostPerson> GetAllMissingPersons()
        {
            return Repository.GetAllLostPersons().Where(p => p.IsFound).ToList();
        }
        public List<ILostPerson> GetByLocation(string location)
        {
            return Repository.GetByLocation(location).ToList();
        }
        public List<ILostPerson> GetByCountry(string country)
        {
            return Repository.GetByCountry(country).ToList();
        }
        public List<ILostPerson> GetByReportDate(DateTime reportDate)
        {
            return Repository.GetByReportDate(reportDate).ToList();
        }
        public List<ILostPerson> GetByDateLastSeen(DateTime lastSeen)
        {
            return Repository.GetByDateLastSeen(lastSeen).ToList();
        }
        public List<ILostPerson> GetByLocationLastSeen(string lastSeen)
        {
            return Repository.GetByLocationLastSeen(lastSeen).ToList();
        }
        public ILostPerson GetLostPersonById(int id)
        {
            return Repository.GetLostPersonById(id);
        }

        public bool ReportMissingPerson(int id)
        {
            if (!Repository.GetAllLostPersons().First(m => m.Id.Equals(id)).IsFound)
            {
                throw new ArgumentOutOfRangeException("IsFound");
            }
            return Repository.ReportMissingPerson(id);
        }
        public List<IRedCross> GetAllRedCrosses()
        {
            return Repository.GetAllRedCrosses().ToList();
        }
        public bool RemoveMissingPerson(int id)
        {
            return Repository.RemoveMissingPerson(id);
        }
    }
}
