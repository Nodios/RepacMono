using System;
using System.Collections.Generic;
using System.Linq;
using Lost.DAL;
using Lost.DAL.Models;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Lost.Common;

namespace Lost.Repository
{
    public class RedRepository : IRedRepository
    {
        private readonly IGenericRepository Repository;

        public RedRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }
        /// <summary>
        /// Find by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IRedCross> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IRedCross>(await Repository.GetAsync<RedCrossEntity>(id));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IRedCross>> GetAsync(/*Paging paging*/)
        {
            
            try
            {
                return AutoMapper.Mapper.Map<IEnumerable<IRedCross>>(await Repository.GetEverything<RedCrossEntity>()).OrderBy(r => r.Name);
                //if (paging == null)
                //{
                //    return AutoMapper.Mapper.Map<IEnumerable<IRedCross>>(await Repository.GetEverything<RedCrossEntity>());
                //}
                //else
                //{
                //    return AutoMapper.Mapper.Map<IEnumerable<IRedCross>>(await Repository.Where<RedCrossEntity>()
                //        .OrderBy(r => r.Name)
                //        .Skip((paging.PageNumber * paging.PageSize) - paging.PageSize)
                //        .Take(paging.PageSize).ToListAsync());
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Add entity
        /// </summary>
        public async Task<int> AddAsync(IRedCross rc)
        {
            try
            {
                return await Repository.AddAsync<RedCrossEntity>(AutoMapper.Mapper.Map<RedCrossEntity>(rc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update entity
        /// </summary>
        public async Task<int> UpdateAsync(IRedCross rc)
        {
            try
            {
                return await Repository.UpdateAsync<RedCrossEntity>(AutoMapper.Mapper.Map<RedCrossEntity>(rc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <returns>1 if deleted, else 0</returns>
        public async Task<int> DeleteAsync(IRedCross rc)
        {
            try
            {
                return await Repository.DeleteAsync<RedCrossEntity>(AutoMapper.Mapper.Map<RedCrossEntity>(rc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete by id
        /// </summary>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await Repository.DeleteAsync<RedCrossEntity>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
