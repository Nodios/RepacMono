using System;
using System.Collections.Generic;

namespace Lost.DAL.Models
{
    public class PersonInChargeEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }

        public Guid RedCrossId { get; set; }
        public virtual RedCrossEntity RedCrossEntity { get; set; }
    }
}
