using System;
using System.Collections.Generic;

namespace Lost.DAL
{
    public class RedCrossEntity
    {
        public int RedCrossId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PersonInCharge { get; set; }

        public List<LostPersonEntity> LostPersons { get; set; }
    }
}
