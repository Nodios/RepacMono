using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lost.DAL.Models
{
    public class ApplicationUserEntity : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }
        public Guid RedCrossId { get; set; }
        public RedCrossEntity RedCrossEntity { get; set; }

        public override string UserName
        {
            get
            {
                return base.UserName;
            }
            set
            {
                base.UserName = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUserEntity> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
