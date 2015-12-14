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
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime DateLastSeen { get; set; }
        public string LocationLastSeen { get; set; }
        public string ReporterName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime ReportDate { get; set; }
        public string Location { get; set; }
        public bool IsFound { get; set; }

        //Foreign key
        public Guid RedCrossId { get; set; }
        
        //Navigation: one to one
        public IRedCross RedCross { get; set; }
    }
}
