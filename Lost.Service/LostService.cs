﻿using Lost.DAL;
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
    public class LostService : EntityService<LostPersonEntity>, ILostService
    {
        IUnitOfWork unitOfWork;
        ILostRepository lostRepository;

        public LostService(IUnitOfWork unitOfWork, ILostRepository lostRepository) 
            : base(unitOfWork, lostRepository)
        {
            this.unitOfWork = unitOfWork;
            this.lostRepository = lostRepository;
        }

        public LostPersonEntity GetById(int id)
        {
            return lostRepository.GetById(id);
        }
        public IEnumerable<LostPersonEntity> GetAllMissing()
        {
            return lostRepository.GetAll().Where(x => x.IsFound == false);
        }
    }
}
