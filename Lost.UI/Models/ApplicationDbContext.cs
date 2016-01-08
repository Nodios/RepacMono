using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using Lost.DAL.Models;
using Lost.UI.Models;

namespace Lost.UI.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("SearchContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}