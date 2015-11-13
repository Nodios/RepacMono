using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.Repository.Common;
using Lost.Service.Common;
using Lost.DAL;

namespace Lost.Service
{
    public class RedService : EntityService<RedCrossEntity>, IRedService
    {
        IUnitOfWork unitOfWork;
        IRedRepository redRepository;

        public RedService(IUnitOfWork unitOfWork, IRedRepository redRepository) 
            : base(unitOfWork, redRepository)
        {
            this.unitOfWork = unitOfWork;
            this.redRepository = redRepository;
        }

        public IEnumerable<RedCrossEntity> GetById(int id)
        {
            //return redRepository.GetById(id);
            return redRepository.FindBy(x => x.Id == id);
        }

        public IEnumerable<RedCrossEntity> GetByCountry(string country)
        {
            return redRepository.GetAll().Where(x => x.Country == country);
        }
    }
}
