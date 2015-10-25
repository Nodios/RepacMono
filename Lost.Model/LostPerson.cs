using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Lost.Model
{
    public class LostPerson : ILostPerson
    {
        public int Id { get; set; }

        //Personal informations
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //Report informations
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLastSeen { get; set; }
        public string LocationLastSeen { get; set; }
        public string ReporterName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReportDate { get; set; }
        public string Location { get; set; }
        public bool IsFound { get; set; }

        //Foreign key
        public int RedCrossId { get; set; }
        
        //Navigation
        public IRedCross RedCross { get; set; }
    }
}
