using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Model.Common
{
    public interface IRedCross
    {
        Guid RedCrossId { get; set; }
        string Name { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string PersonInCharge { get; set; }

        ICollection<ILostPerson> LostPersons { get; set; }
    }
}
