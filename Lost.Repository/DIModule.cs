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
            //                             SOURCE         DESTINATION
            AutoMapper.Mapper.CreateMap<LostPersonEntity, LostPerson>().ReverseMap();
            AutoMapper.Mapper.CreateMap<LostPersonEntity, ILostPerson>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ILostPerson, LostPerson>().ReverseMap();

            AutoMapper.Mapper.CreateMap<RedCrossEntity, RedCross>().ReverseMap();
            AutoMapper.Mapper.CreateMap<RedCrossEntity, IRedCross>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IRedCross, RedCross>().ReverseMap();

            Bind<ISearchContext>().To<SearchContext>().InSingletonScope();
            Bind<ILostRepository>().To<LostRepository>();
        }
    }
}