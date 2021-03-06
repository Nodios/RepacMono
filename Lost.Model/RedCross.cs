﻿using System.Collections.Generic;
using Lost.Model.Common;
using System;

namespace Lost.Model
{
    public class RedCross : IRedCross
    {
        public Guid RedCrossId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PersonInCharge { get; set; }

        //Navigation one to many
        public virtual ICollection<ILostPerson> LostPersons { get; set; }
        public virtual ICollection<IApplicationUser> ApplicationUsers { get; set; }
    }
}
