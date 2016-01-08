using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.Models
{
    public partial class SearchContext : IdentityDbContext<ApplicationUser>
    {
        public SearchContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SearchContext Create()
        {
            return new SearchContext();
        }
    }
}