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
    public class IdentityEntity : IdentityUser
    {
        public virtual PersonInChargeEntity PersonInCharge { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityEntity> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
