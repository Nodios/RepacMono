using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.Repository.Common;
using Lost.Service.Common;
using Lost.DAL;

namespace Lost.Service
{
    public class LostService : ILostService
    {
        protected IUnitOfWork _unitOfWork { get; set; }
        protected ILostRepository Repository { get; set; }

        public LostService(IUnitOfWork unitOfWork, ILostRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this.Repository = repository;
        }

        #region ILostService Members
        public IEnumerable<ILostPerson> GetAllMissingPersons()
        {
            return (IEnumerable<ILostPerson>)Repository.GetAll().Where(p => !p.IsFound);
        }

        public IEnumerable<ILostPerson> GetByLocation(string location)
        {
            return Repository.GetByLocation(location);
        }

        public IEnumerable<ILostPerson> GetByCountry(string country)
        {
            return Repository.GetByCountry(country);
        }

        public IEnumerable<ILostPerson> GetByReportDate(DateTime reportDate)
        {
            return Repository.GetByReportDate(reportDate);
        }

        public IEnumerable<ILostPerson> GetByDateLastSeen(DateTime lastSeen)
        {
            return Repository.GetByDateLastSeen(lastSeen);
        }

        public IEnumerable<ILostPerson> GetByLocationLastSeen(string lastSeen)
        {
            return Repository.GetByLocationLastSeen(lastSeen);
        }

        public bool ReportMissingPerson(LostPersonEntity lpe)
        {
            try
            {
                Repository.Add(lpe);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void UpdateMissingPerson(LostPersonEntity lpe)
        {
            Repository.Update(lpe);
            _unitOfWork.Commit();
        }

        public void DeleteMissingPerson(int id)
        {
            var delete = Repository.GetById(id);
            Repository.Delete(delete);
            _unitOfWork.Commit();
        }

        public void SaveMissingPerson()
        {
            _unitOfWork.Commit();
        }
        #endregion

        #region Comments
        /*
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
        }*/
        #endregion

    }
}
