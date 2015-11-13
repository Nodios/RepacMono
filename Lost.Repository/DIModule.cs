using System;
using Lost.DAL;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;

namespace Lost.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            //Only one context to exist
            Bind<ISearchContext>().To<SearchContext>().InSingletonScope();

            Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            Bind<ILostRepository>().To<LostRepository>();
            Bind<IRedRepository>().To<RedRepository>();

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}