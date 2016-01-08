using Lost.DAL;
using Lost.DAL.Models;
using Lost.Model.Common;
using Lost.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Lost.Repository
{
    public class PersonInChargeRepository : IPersonInChargeRepository
    {
        protected IGenericRepository Repository { get; private set; }

        public PersonInChargeRepository(IGenericRepository repository)
        {
            Repository = repository;
        }

        public async Task<IPersonInCharge> GetAsync(string id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IPersonInCharge>(await Repository.GetAsync<PersonInChargeEntity>(p => p.Id.Equals(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPersonInCharge> GetCurrentAsync()
        {
            try
            {
                var id = ClaimsPrincipal.Current.Identity.GetUserId();
                return AutoMapper.Mapper.Map<IPersonInCharge>(await Repository.Where<PersonInChargeEntity>().Where(p => p.Id.Equals(id)).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(IPersonInCharge pic)
        {
            try
            {
                return await Repository.AddAsync<PersonInChargeEntity>(AutoMapper.Mapper.Map<PersonInChargeEntity>(pic));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(IPersonInCharge pic)
        {
            try
            {
                pic.Id = Guid.NewGuid().ToString();
                return await Repository.UpdateAsync<PersonInChargeEntity>(AutoMapper.Mapper.Map<PersonInChargeEntity>(pic));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(IPersonInCharge pic)
        {
            try
            {
                return await Repository.DeleteAsync<PersonInChargeEntity>(AutoMapper.Mapper.Map<PersonInChargeEntity>(pic));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> DeleteAsync(string id)
        {
            try
            {
                return await this.DeleteAsync(AutoMapper.Mapper.Map<IPersonInCharge>(await Repository.GetAsync<PersonInChargeEntity>(p => p.Id.Equals(id))));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
