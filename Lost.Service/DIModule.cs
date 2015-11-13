using System;
using Lost.Service.Common;
using Lost.Repository.Common;

namespace Lost.Service
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IEntityService<>)).To(typeof(EntityService<>));
            Bind<ILostService>().To<LostService>();
            Bind<IRedService>().To<RedService>();
        }
    }
}
