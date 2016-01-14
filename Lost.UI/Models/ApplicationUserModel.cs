using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }
        public Guid RedCrossId { get; set; }
        public RedCrossModel RedCrossModel{ get; set; }
    }
}