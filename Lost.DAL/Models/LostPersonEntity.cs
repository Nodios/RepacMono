using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lost.DAL.Models
{
    public partial class LostPersonEntity
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

        public Guid RedCrossEntityId { get; set; }

        //one to one, one missing person can be reported in only one Red cross
        public virtual RedCrossEntity RedCrossEntity { get; set; }
    }
}
