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
using Lost.Common.Filters;
using PagedList;

namespace Lost.Repository
{
    public class LostRepository : ILostRepository
    {
        protected IGenericRepository Repository { get; private set; }

        public LostRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<ILostPerson> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<ILostPerson>(await Repository.GetAsync<LostPersonEntity>(id)); //Destination ILostPerson; Source LostPersonEntity
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get all lost person from red cross
        /// </summary>
        /// <param name="redCrossId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ILostPerson>> GetAllAsync(Guid redCrossId, LostPersonFilter filter)
        {
            try
            {
                if (filter != null)
                {
                    var lp = AutoMapper.Mapper.Map<IEnumerable<ILostPerson>>(await Repository.GetEverything<LostPersonEntity>()).OrderBy(l => l.LastName).ToList();

                    if (redCrossId != null)
                    {
                        lp = lp.Where(l => l.RedCrossId.Equals(redCrossId)).ToList();
                    }

                    var page = lp.ToPagedList(filter.pageNumber, filter.pageSize);
                    var lpPage = new StaticPagedList<ILostPerson>(page, page.GetMetaData());
                    return lpPage;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<ILostPerson>>(await Repository.GetAllAsync<LostPersonEntity>(l => l.RedCrossId.Equals(redCrossId))).OrderBy(l => l.ReportDate).ToList();
                }

                //return AutoMapper.Mapper.Map<IEnumerable<ILostPerson>>(await Repository.GetAllAsync<LostPersonEntity>(l => l.RedCrossEntityId.Equals(redCrossId))).OrderBy(l => l.LastName); //Destination ILostPerson; Source: LostPersonEntity
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get all lost persons
        /// </summary>
        /// <returns>List of lost persons</returns>
        public async Task<IEnumerable<ILostPerson>> GetEveryoneAsync(LostPersonFilter filter)
        {
            try
            {
                if (filter != null)
                {
                    var lp = AutoMapper.Mapper.Map<IEnumerable<ILostPerson>>(await Repository.GetEverything<LostPersonEntity>()).OrderBy(l => l.LastName).ToList(); //Fetch all lost, order by last name, add to list

                    if (!string.IsNullOrWhiteSpace(filter.searchString))
                    {
                        //Filter entire list
                        lp = lp.Where(l => 
                            l.LastName.ToLower().Contains(filter.searchString.ToLower()) ||
                            l.FirstName.ToLower().Contains(filter.searchString.ToLower()) ||
                            l.LocationLastSeen.ToLower().Contains(filter.searchString.ToLower())
                        ).ToList();
                    }

                    //Page filtered data
                    var page = lp.ToPagedList(filter.pageNumber, filter.pageSize);
                    var lpPage = new StaticPagedList<ILostPerson>(page, page.GetMetaData());
                    return lpPage;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<ILostPerson>>(await Repository.GetEverything<LostPersonEntity>()).OrderBy(l => l.LastName).ToList(); //Destination ILostPerson; Source: LostPersonEntity
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

                //return AutoMapper.Mapper.Map<IEnumerable<ILostPerson>>(await Repository.GetEverything<LostPersonEntity>()).OrderBy(l => l.LastName); //Destination ILostPerson; Source: LostPersonEntity
        }

        #region A/U/D
        /// <summary>
        /// Add lost person
        /// </summary>
        public async Task<int> AddAsync(ILostPerson lp)
        {
            try
            {
                lp.Id = Guid.NewGuid();
                return await Repository.AddAsync<LostPersonEntity>(AutoMapper.Mapper.Map<LostPersonEntity>(lp)); //Destination LostPersonEntity; Source ILostPerson
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update lost person 
        /// </summary>
        public async Task<int> UpdateAsync(ILostPerson lp)
        {
            try
            {
                return await Repository.UpdateAsync<LostPersonEntity>(AutoMapper.Mapper.Map<LostPersonEntity>(lp));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete lost person
        /// </summary>
        public async Task<int> DeleteAsync(ILostPerson lp)
        {
            try
            {
                return await Repository.DeleteAsync<LostPersonEntity>(AutoMapper.Mapper.Map<LostPersonEntity>(lp));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// params - optional parametar(id) that can be passed to the method or not
        /// </summary>
        /// <param name="id">param id</param>
        public async Task<int> DeleteAsync(params Guid[] id)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();
                foreach (Guid i in id)
                {
                    await uow.DeleteAsync<LostPersonEntity>(i);
                }
                return await uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
