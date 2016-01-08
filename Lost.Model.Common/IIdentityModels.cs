using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Model.Common
{
    public interface IApplicationUser
    {
        IPersonInCharge PersonInCharge { get; set; }
    }
}
