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

namespace Lost.Repository
{
    public class LostRepository : ILostRepository
    {
        private readonly IGenericRepository Repository;

        public LostRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<ILostPerson> GetAsync(int id)
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
        public async Task<IEnumerable<ILostPerson>> GetAllAsync(int redCrossId)
        {
            try
            {
                return AutoMapper.Mapper.Map<IEnumerable<ILostPerson>>(await Repository.GetAllAsync<LostPersonEntity>(l => l.RedCrossId.Equals(redCrossId))); //Destination ILostPerson; Source: LostPersonEntity
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
        public async Task<IEnumerable<ILostPerson>> GetEveryoneAsync()
        {
            try
            {
                return AutoMapper.Mapper.Map<IEnumerable<ILostPerson>>(await Repository.GetEverything<LostPersonEntity>()); //Destination ILostPerson; Source: LostPersonEntity
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region A/U/D
        /// <summary>
        /// Add lost person
        /// </summary>
        public async Task<int> AddAsync(ILostPerson lp)
        {
            try
            {
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
        public async Task<int> DeleteAsync(params int[] id)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();
                foreach (int i in id)
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
