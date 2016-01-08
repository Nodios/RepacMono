using Lost.Common.Filters;
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
        protected ILostRepository lostRepository { get; private set; }

        public LostService(ILostRepository lostRepository)
        {
            this.lostRepository = lostRepository;
            if (lostRepository == null) throw new ArgumentNullException("lostRepository is null. Must be ILostRepository");
        }

        public Task<ILostPerson> FindByIdAsync(Guid id)
        {
            return lostRepository.GetAsync(id);
        }

        public virtual Task<IEnumerable<ILostPerson>> GetAllLostPersons(GenericFilter filter)
        {
            try
            {
                return lostRepository.GetEveryoneAsync(filter);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<ILostPerson>> GetFromRedCross(Guid id, GenericFilter filter)
        {
            return lostRepository.GetAllAsync(id);
        }

        #region C-UD
        public Task<int> ReportLostPerson(ILostPerson lp)
        {
            try
            {
                return lostRepository.AddAsync(lp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> UpdateLostPerson(ILostPerson lp)
        {
            return lostRepository.UpdateAsync(lp);
        }

        public Task<int> DeleteMissingPerson(Guid id)
        {
            return lostRepository.DeleteAsync(id);
        }
        #endregion
    }
}
