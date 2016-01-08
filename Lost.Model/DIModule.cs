using System;
using Lost.Model.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Lost.DAL.Models;
using Lost.DAL;
using System.Data.Entity;

namespace Lost.Model
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ILostPerson>().To<LostPerson>();
            Bind<IRedCross>().To<RedCross>();
            Bind<IPersonInCharge>().To<PersonInCharge>();

            //For roles
            Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole>>();
            Bind<RoleManager<IdentityRole>>().ToSelf();

            //For users
            Bind(typeof(IUserStore<ApplicationUserEntity>)).To(typeof(UserStore<ApplicationUserEntity>));
            Bind(typeof(UserManager<ApplicationUserEntity>)).ToSelf();
            Bind(typeof(DbContext)).To(typeof(SearchContext));
        }
    }
}
