using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.Models
{
    public class LostPersonModel
    {
        public int Id { get; set; }

        //Personal informations
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //Report informations
        public DateTime DateLastSeen { get; set; }
        public string LocationLastSeen { get; set; }
        public string ReporterName { get; set; }
        public DateTime ReportDate { get; set; }
        public string Location { get; set; }
        public bool IsFound { get; set; }
    }
}