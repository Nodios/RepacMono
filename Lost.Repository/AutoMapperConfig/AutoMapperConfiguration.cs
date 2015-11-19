using Lost.DAL.Models;
using Lost.Model;
using Lost.Model.Common;

namespace Lost.Repository
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigureLostPersonMapping();
            ConfigureRedCrossMapping();
        }
        private static void ConfigureLostPersonMapping()
        {
            //                             SOURCE         DESTINATION
            AutoMapper.Mapper.CreateMap<LostPersonEntity, LostPerson>().ReverseMap();
            AutoMapper.Mapper.CreateMap<LostPersonEntity, ILostPerson>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ILostPerson, LostPerson>().ReverseMap();
        }
        private static void ConfigureRedCrossMapping()
        {
            //                             SOURCE         DESTINATION
            AutoMapper.Mapper.CreateMap<RedCrossEntity, RedCross>().ReverseMap();
            AutoMapper.Mapper.CreateMap<RedCrossEntity, IRedCross>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IRedCross, RedCross>().ReverseMap();
        }
    }
}
