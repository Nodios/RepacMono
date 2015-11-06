using System;
using System.Collections.Generic;
using System.Linq;
using Lost.DAL;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Lost.Repository
{
    public class LostRepository : EntityBase<LostPersonEntity>, ILostRepository
    {
        public LostRepository(SearchContext context) : base(context)
        {
            //this.Context = context;
        }
        //protected SearchContext Context { get; set; }

        public IQueryable<LostPersonEntity> GetAllWithRedCross()
        {
            var lp = _dbSet.Include("RedCrosses");
            return lp;
        }


        #region some testings
        /*
        public IEnumerable<ILostPerson> GetByLocation(string location)
        {
            var person = _dbSet.Where(p => p.Location.Equals(location));
            //var vrati = new List<ILostPerson>(AutoMapper.Mapper.Map<ICollection<LostPerson>>(person));

            //return ICollection<ILostPerson>(AutoMapper.Mapper.Map<ICollection<LostPerson>>(_dbSet.Where(p => p.Location.Equals(location)).ToList()));
            return AutoMapper.Mapper.Map<ICollection<ILostPerson>>(person);
        }

        public ICollection<ILostPerson> GetByCountry(string country)
        {
            //var person = _dbSet.Where(p => p.Location.Equals(country)).ToList();
            //var vrati = new List<ILostPerson>(AutoMapper.Mapper.Map<IQueryable<LostPerson>>(person));

            return new List<ILostPerson>(AutoMapper.Mapper.Map<ICollection<LostPerson>>(_dbSet.Where(p => p.Location.Equals(country)).ToList()));
        }

        public ICollection<ILostPerson> GetByReportDate(DateTime reportDate)
        {
            //var person = _dbSet.Where(p => p.Location.Equals(reportDate)).ToList();
            //var vrati = new List<ILostPerson>(AutoMapper.Mapper.Map<IQueryable<LostPerson>>(person));

            return new List<ILostPerson>(AutoMapper.Mapper.Map<ICollection<LostPerson>>(_dbSet.Where(p => p.Location.Equals(reportDate)).ToList()));
        }

        public ICollection<ILostPerson> GetByDateLastSeen(DateTime lastSeen)
        {
            //var person = _dbSet.Where(p => p.Location.Equals(lastSeen));
            //var vrati = new List<ILostPerson>(AutoMapper.Mapper.Map<IQueryable<LostPerson>>(person));

            return new List<ILostPerson>(AutoMapper.Mapper.Map<ICollection<LostPerson>>(_dbSet.Where(p => p.Location.Equals(lastSeen)).ToList()));
        }

        public ICollection<ILostPerson> GetByLocationLastSeen(string lastSeen)
        {
            //var person = _dbSet.Where(p => p.Location.Equals(lastSeen)).ToList();
            //var vrati = new List<ILostPerson>(AutoMapper.Mapper.Map<IQueryable<LostPerson>>(person));

            return new List<ILostPerson>(AutoMapper.Mapper.Map<ICollection<LostPerson>>(_dbSet.Where(p => p.Location.Equals(lastSeen)).ToList()));
        }*/
        #endregion


        #region Not Needed
        /*
        public List<ILostPerson> GetByLocation(string location)
        {
            //var person = Context.LostPersons.Find(m => m.Location == location);
            //return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(person));

            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Where(m => m.Location.Equals(location))));
        }
        public List<ILostPerson> GetByCountry(string country)
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Where(m => m.Country.Equals(country))));
        }
        public List<ILostPerson> GetByReportDate(DateTime reportDate)
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Where(m => m.ReportDate.Equals(reportDate))));
        }
        public List<ILostPerson> GetByDateLastSeen(DateTime lastSeen)
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Where(m => m.DateLastSeen.Equals(lastSeen))));
        }
        public List<ILostPerson> GetByLocationLastSeen(string lastSeen)
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Where(m => m.LocationLastSeen.Equals(lastSeen))));
        }
        public ILostPerson GetLostPersonById(int id)
        {
            //var person = Context.LostPersons.Find(m => m.Id.Equals(id));
            //return AutoMapper.Mapper.Map<ILostPerson>(person);

            return AutoMapper.Mapper.Map<ILostPerson>(Context.LostPersons.Where(m => m.Id.Equals(id)));
        }
         */
        #endregion


    }
}
