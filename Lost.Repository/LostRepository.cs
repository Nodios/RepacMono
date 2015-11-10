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
    public class LostRepository : EntityBase<ILostPerson, SearchContext>, ILostRepository
    {
        public IQueryable<ILostPerson> GetFromLocation(string loc)
        {
            var query = GetAll().Where(x => x.LocationLastSeen.Equals(loc));

            return AutoMapper.Mapper.Map<IQueryable<ILostPerson>>(query);
        }

        public ILostPerson GetById(int? id)
        {
            var query = GetAll().Where(x => x.Id.Equals(id));

            return AutoMapper.Mapper.Map<ILostPerson>(query);
        }

        public IEnumerable<ILostPerson> GetAllMissing()
        {
            return AutoMapper.Mapper.Map<IQueryable<ILostPerson>>(GetAll());
        }
    }
}
