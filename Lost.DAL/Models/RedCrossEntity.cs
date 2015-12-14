using System;
using System.Collections.Generic;

namespace Lost.DAL.Models
{
    public partial class RedCrossEntity
    {
        public Guid RedCrossId { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PersonInCharge { get; set; }

        //one to many, one RC can have many reported persons
        public virtual ICollection<LostPersonEntity> LostPersonEntities { get; set; }
    }
}
