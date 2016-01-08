using Lost.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Repository.Common
{
    public interface IUserRepository
    {
        Task<IApplicationUser> GetAsync(string id);
        Task<IApplicationUser> GetAsync(string username, string password);

        Task<int> AddAsync(IApplicationUser user);
        Task<bool> RegisterUser(IApplicationUser user, string password);

        Task<int> UpdateAsync(IApplicationUser user);

        Task<int> DeleteAsync(IApplicationUser user);
        Task<int> DeleteAsync(string id);
    }
}
