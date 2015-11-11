using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;

namespace Lost.Repository.Common
{
    public interface ILostRepository : IGenericRepository<ILostPerson>
    {
        ILostPerson GetById(int id);
    }
}
