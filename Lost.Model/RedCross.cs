using System.Collections.Generic;
using Lost.Model.Common;
using System;

namespace Lost.Model
{
    public class RedCross : IRedCross
    {
        public int RedCrossId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PersonInCharge { get; set; }

        public List<ILostPerson> LostPersons { get; set; }
    }
}
