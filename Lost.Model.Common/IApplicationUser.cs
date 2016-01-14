using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Model.Common
{
    public interface IApplicationUser
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string OIB { get; set; }
        Guid RedCrossId { get; set; }
        IRedCross RedCross { get; set; }
    }
}
