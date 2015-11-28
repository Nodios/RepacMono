using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Model.Common
{
    public interface ILostPerson
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime Birthday { get; set; }
        string City { get; set; }
        string Country { get; set; }
        DateTime DateLastSeen { get; set; }
        string LocationLastSeen { get; set; }
        string ReporterName { get; set; }
        DateTime ReportDate { get; set; }
        string Location { get; set; }
        bool IsFound { get; set; }

        //FK
        Guid RedCrossId { get; set; }

        //Navigation
        IRedCross RedCross { get; set; }
    }
}
