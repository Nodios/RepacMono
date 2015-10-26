﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lost.DAL;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;

namespace Lost.Repository
{
    public class LostRepository : ILostRepository
    {
        public LostRepository(ISearchContext context)
        {
            this.Context = context;
        }
        protected ISearchContext Context { get; private set; }

        //THIS MIGHT GO INTO SERVICE LAYER
        public List<ILostPerson> GetAllLostPersons()
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<Lost.Model.LostPerson>>(Context.LostPersons.Where(p => !p.IsFound)));
        }
        public List<ILostPerson> GetByLocation(string location)
        {
            //var person = Context.LostPersons.Find(m => m.Location == location);
            //return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(person));

            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Find(m => m.Location.Equals(location))));
        }
        public List<ILostPerson> GetByCountry(string country)
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Find(m => m.Country.Equals(country))));
        }
        public List<ILostPerson> GetByReportDate(DateTime reportDate)
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Find(m => m.ReportDate.Equals(reportDate))));
        }
        public List<ILostPerson> GetByDateLastSeen(DateTime lastSeen)
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Find(m => m.DateLastSeen.Equals(lastSeen))));
        }
        public List<ILostPerson> GetByLocationLastSeen(string lastSeen)
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<LostPerson>>(Context.LostPersons.Find(m => m.LocationLastSeen.Equals(lastSeen))));
        }
        public ILostPerson GetLostPersonById(int id)
        {
            //var person = Context.LostPersons.Find(m => m.Id.Equals(id));
            //return AutoMapper.Mapper.Map<ILostPerson>(person);

            return AutoMapper.Mapper.Map<ILostPerson>(Context.LostPersons.Find(m => m.Id.Equals(id)));
        }

        //CRUD
        public bool ReportMissingPerson(int id)
        {
            Context.RedCrosses.FirstOrDefault().LostPersons.Add(Context.LostPersons.First(m => m.Id.Equals(id)));
            return true;
        }
        public List<ILostPerson> GetAllLostPersons()
        {
            return new List<ILostPerson>(AutoMapper.Mapper.Map<List<Lost.Model.LostPerson>>(Context.LostPersons));
        }
        public List<IRedCross> GetAllRedCrosses()
        {
            return new List<IRedCross>(AutoMapper.Mapper.Map<List<Lost.Model.RedCross>>(Context.RedCrosses));
        }
        public bool RemoveMissingPerson(int id)
        {
            return Context.RedCrosses.FirstOrDefault().LostPersons.Remove(Context.LostPersons.First(m => m.Id.Equals(id)));
        }
    }
}
