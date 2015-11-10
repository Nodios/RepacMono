using Lost.DAL;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;
using Lost.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Service
{
    public class LostService : ILostService
    {
        #region Constructor
        //private IUnitOfWork _unitOfWork { get; set; }
        protected ILostRepository Repository { get; private set; }

        public LostService(/*IUnitOfWork unitOfWork,*/ ILostRepository repository)
        {
            //this._unitOfWork = unitOfWork;
            this.Repository = repository;
        }
        #endregion

        #region ILostService Members
        public IEnumerable<ILostPerson> GetAllMissingPersons()
        {
            //var all = Repository.GetAll();
            return Repository.GetAllMissing();
        }
        #endregion

        public bool ReportMissingPerson(ILostPerson lpe)
        {
            try
            {
                Repository.Add(lpe);
                //_unitOfWork.Commit();
                Repository.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void UpdateMissingPerson(ILostPerson lpe)
        {
            Repository.Update(lpe);
            //_unitOfWork.Commit();
            Repository.Save();
        }

        public void DeleteMissingPerson(int id)
        {
            var delete = Repository.GetById(id);
            Repository.Delete(delete);
            //_unitOfWork.Commit();
            Repository.Save();
        }

        public ILostPerson GetMissingPersonById(int? id)
        {
            return Repository.GetById(id);
        }

        public void SaveMissingPerson()
        {
            //_unitOfWork.Commit();
            Repository.Save();
        }


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
