using System;
using Lost.Service.Common;

namespace Lost.Service
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ILostService>().To<LostService>();
        }
    }
}
