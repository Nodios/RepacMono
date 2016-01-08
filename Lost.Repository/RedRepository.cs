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
using Lost.Common.Filters;
using PagedList;

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
        public async Task<IEnumerable<IRedCross>> GetAsync(GenericFilter filter)
        {
            
            try
            {
                if (filter != null)
                {
                    var rc = AutoMapper.Mapper.Map<IEnumerable<IRedCross>>(await Repository.GetEverything<RedCrossEntity>()).OrderBy(r => r.Name).ToList();

                    if (!string.IsNullOrWhiteSpace(filter.searchString))
                    {
                        rc = rc.Where(r =>
                            r.Name.ToLower().Contains(filter.searchString.ToLower()) ||
                            r.Country.ToLower().Contains(filter.searchString.ToLower())
                        ).ToList();
                    }

                    var page = rc.ToPagedList(filter.pageNumber, filter.pageSize);
                    var rcPage = new StaticPagedList<IRedCross>(page, page.GetMetaData());
                    return rcPage;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<IRedCross>>(await Repository.GetEverything<RedCrossEntity>()).OrderBy(r => r.Name).ToList();
                }
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
