using Lost.Repository.Common;
using Lost.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Service
{
    public class UserService : IUserService
    {
        protected IUserRepository Repository { get; private set; }

        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

        public Task<Model.Common.IApplicationUser> GetAsync(string id)
        {
            return Repository.GetAsync(id);
        }

        public Task<Model.Common.IApplicationUser> GetAsync(string username, string password)
        {
            return Repository.GetAsync(username, password);
        }

        public Task<int> AddAsync(Model.Common.IApplicationUser user)
        {
            return Repository.AddAsync(user);
        }

        public Task<bool> RegisterUser(Model.Common.IApplicationUser user, string password)
        {
            return Repository.RegisterUser(user, password);
        }

        public Task<int> UpdateAsync(Model.Common.IApplicationUser user)
        {
            return Repository.UpdateAsync(user);
        }

        public Task<int> DeleteAsync(Model.Common.IApplicationUser user)
        {
            return Repository.DeleteAsync(user);
        }

        public Task<int> DeleteAsync(string id)
        {
            return Repository.DeleteAsync(id);
        }
    }
}
