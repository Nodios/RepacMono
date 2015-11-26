using AutoMapper;
using Lost.DAL.Models;
using Lost.Model;
using Lost.Model.Common;

namespace Lost.Repository
{
    public class AutoMapperConfiguration : Profile
    {
        protected override void Configure()
        {
            ConfigureLostPersonMapping();
            ConfigureRedCrossMapping();
        }
        private static void ConfigureLostPersonMapping()
        {
            //                             SOURCE         DESTINATION
            Mapper.CreateMap<LostPersonEntity, LostPerson>().ReverseMap();
            Mapper.CreateMap<LostPersonEntity, ILostPerson>().ReverseMap();
            Mapper.CreateMap<ILostPerson, LostPerson>().ReverseMap();
        }
        private static void ConfigureRedCrossMapping()
        {
            //                             SOURCE         DESTINATION
            Mapper.CreateMap<RedCrossEntity, RedCross>().ReverseMap();
            Mapper.CreateMap<RedCrossEntity, IRedCross>().ReverseMap();
            Mapper.CreateMap<IRedCross, RedCross>().ReverseMap();
        }
    }
}
