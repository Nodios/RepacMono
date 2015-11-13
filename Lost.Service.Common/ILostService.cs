﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;

namespace Lost.Service.Common
{
    public interface ILostService : IEntityService<LostPersonEntity>
    {
        IEnumerable<LostPersonEntity> GetById(int id);
        IEnumerable<LostPersonEntity> GetAllMissing();
    }
}
