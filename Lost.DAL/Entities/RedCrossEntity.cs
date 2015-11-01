using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lost.DAL
{
    public class RedCrossEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PersonInCharge { get; set; }

        public ICollection<LostPersonEntity> LostPersons { get; set; }
    }
}
