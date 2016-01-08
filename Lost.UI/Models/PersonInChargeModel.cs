using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.Models
{
    public class PersonInChargeModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public Guid RedCrossId { get; set; }
        public virtual RedCrossModel RedCross { get; set; }
        public virtual ApplicationUserModel User { get; set; }
    }
}