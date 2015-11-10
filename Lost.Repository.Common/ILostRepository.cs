using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using Lost.DAL;

namespace Lost.Repository.Common
{
    public interface ILostRepository : IEntityBase<ILostPerson>
    {
        void Add(ILostPerson lp);
        void Update(ILostPerson lp);
        void Delete(ILostPerson lp);
        ILostPerson GetById(int? id);
        IEnumerable<ILostPerson> GetAllMissing();
    }
}
