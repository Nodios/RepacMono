using Lost.DAL;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;
using Lost.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Service
{
    public class LostService : ILostService
    {
        private readonly ILostRepository lostRepository;

        public LostService(ILostRepository lostRepository)
        {
            this.lostRepository = lostRepository;
            if (lostRepository == null) throw new ArgumentNullException("lostRepository is null. Must be ILostRepository");
        }

        public Task<ILostPerson> FindByIdAsync(Guid id)
        {
            return lostRepository.GetAsync(id);
        }

        public Task<IEnumerable<ILostPerson>> GetAllLostPersons()
        {
            return lostRepository.GetEveryoneAsync();
        }

        public Task<int> ReportLostPerson(ILostPerson lp)
        {
            return lostRepository.AddAsync(lp);
        }

        public Task<int> UpdateLostPerson(ILostPerson lp)
        {
            return lostRepository.UpdateAsync(lp);
        }

        public Task<int> DeleteMissingPerson(ILostPerson lp)
        {
            return lostRepository.DeleteAsync(lp);
        }
    }
}
