using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public virtual PersonInChargeModel PersonInCharge { get; set; }
    }
}