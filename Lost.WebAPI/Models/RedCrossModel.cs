using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.WebAPI.Models
{
    public class RedCrossModel
    {
        public RedCrossModel()
        {
            this.LostPersonModels = new List<LostPersonModel>();
        }

        public int RedCrossId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PersonInCharge { get; set; }
        public virtual ICollection<LostPersonModel> LostPersonModels { get; set; }
    }
}