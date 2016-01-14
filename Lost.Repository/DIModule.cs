using System;
using Lost.DAL;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;
using Ninject.Extensions.Factory;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Lost.DAL.Models;

namespace Lost.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            //Context
            Bind<ISearchContext>().To<SearchContext>();//.InSingletonScope()

            //Generic repository and unit of work
            Bind<IGenericRepository>().To<GenericRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().ToFactory(); // https://github.com/ninject/Ninject.Extensions.Factory/wiki/Factory-interface


            Bind<ILostRepository>().To<LostRepository>();
            Bind<IRedRepository>().To<RedRepository>();
            Bind<IUserRepository>().To<UserRepository>();

            Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole>>();
            Bind<RoleManager<IdentityRole>>().ToSelf();

            Bind(typeof(IUserStore<ApplicationUserEntity>)).To(typeof(UserStore<ApplicationUserEntity>));
            Bind(typeof(UserManager<ApplicationUserEntity>)).ToSelf();
            Bind(typeof(DbContext)).To(typeof(SearchContext));

        }
    }
}