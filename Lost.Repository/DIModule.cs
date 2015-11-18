using System;
using Lost.DAL;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;
using Ninject.Extensions.Factory;

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
            Bind<IUnitOfWorkFactory>().ToFactory(); //specified by: https://github.com/ninject/Ninject.Extensions.Factory/wiki/Factory-interface


            Bind<ILostRepository>().To<LostRepository>();
            Bind<IRedRepository>().To<RedRepository>();


        }
    }
}