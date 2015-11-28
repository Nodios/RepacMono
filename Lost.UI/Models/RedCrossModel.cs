using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.Models
{
    public class RedCrossModel
    {
        public Guid RedCrossModelId { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PersonInCharge { get; set; }

        //one to many, one RC can have many reported persons
        public virtual ICollection<LostPersonModel> LostPersonModel { get; set; }
    }
    
}