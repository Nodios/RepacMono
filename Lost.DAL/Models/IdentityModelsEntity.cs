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
        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (String.IsNullOrEmpty(Id))
                    base.Id = Guid.NewGuid().ToString();
                else
                    base.Id = value;
            }
        }

        public virtual PersonInChargeEntity PersonInChargeEntity { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUserEntity> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
