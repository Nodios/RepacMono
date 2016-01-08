using Lost.DAL.Models;
using Lost.Model.Common;
using Lost.Repository.Common;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Repository
{
    public class UserRepository : IUserRepository
    {
        protected IGenericRepository Repository { get; private set; }
        protected UserManager<ApplicationUserEntity> UserManager { get; private set; }
        protected IUnitOfWork UnitOfWork { get; private set; }


        public UserRepository(IGenericRepository repository, UserManager<ApplicationUserEntity> userManager, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UserManager = userManager;
            UnitOfWork = unitOfWork;
        }

        public async Task<IApplicationUser> GetAsync(string id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IApplicationUser>(await Repository.GetAsync<ApplicationUserEntity>(p => p.Id.Equals(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IApplicationUser> GetAsync(string username, string password)
        {
            try
            {
                return AutoMapper.Mapper.Map<IApplicationUser>(await UserManager.FindAsync(username, password));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(IApplicationUser user)
        {
            try
            {
                return await Repository.AddAsync<ApplicationUserEntity>(AutoMapper.Mapper.Map<ApplicationUserEntity>(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RegisterUser(IApplicationUser user, string password)
        {
            try
            {
                IdentityResult result = await UserManager.CreateAsync(AutoMapper.Mapper.Map<ApplicationUserEntity>(user), password);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(IApplicationUser user)
        {
            try
            {
                return await Repository.UpdateAsync<ApplicationUserEntity>(AutoMapper.Mapper.Map<ApplicationUserEntity>(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(IApplicationUser user)
        {
            try
            {
                return await Repository.DeleteAsync<ApplicationUserEntity>(AutoMapper.Mapper.Map<ApplicationUserEntity>(user));
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
                return await this.DeleteAsync(AutoMapper.Mapper.Map<IApplicationUser>(await Repository.GetAsync<ApplicationUserEntity>(u => u.Id.Equals(id))));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
