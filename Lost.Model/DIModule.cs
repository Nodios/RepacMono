using Lost.Model.Common;

namespace Lost.Model
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ILostPerson>().To<LostPerson>();
            Bind<IRedCross>().To<RedCross>();
        }
    }
}
