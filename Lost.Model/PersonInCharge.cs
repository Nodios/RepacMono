using Lost.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Model
{
    public class PersonInCharge : IPersonInCharge
    {
        public string Id { get; set; }
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
        public virtual IRedCross RedCross { get; set; }
        public virtual IApplicationUser User { get; set; }
    }
}
