using System;
using System.Collections.Generic;

namespace Lost.DAL.Models
{
    public partial class RedCrossEntity
    {
        public RedCrossEntity()
        {
            this.LostPersonEntities = new List<LostPersonEntity>();
        }

        public int RedCrossId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PersonInCharge { get; set; }
        public virtual ICollection<LostPersonEntity> LostPersonEntities { get; set; }
    }
}
