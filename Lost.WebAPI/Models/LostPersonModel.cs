using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.WebAPI.Models
{
    public class LostPersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public System.DateTime DateLastSeen { get; set; }
        public string LocationLastSeen { get; set; }
        public string ReporterName { get; set; }
        public System.DateTime ReportDate { get; set; }
        public string Location { get; set; }
        public bool IsFound { get; set; }
        public int RedCrossId { get; set; }
        public virtual RedCrossModel RedCrossModels { get; set; }
    }
}