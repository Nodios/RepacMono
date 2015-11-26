using AutoMapper;
using Lost.Model;
using Lost.Model.Common;
using Lost.WebAPI.Models;


namespace Lost.WebAPI.App_Start
{
    public class WebApiMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ILostPerson, LostPersonModel>().ReverseMap();
            Mapper.CreateMap<LostPerson, LostPersonModel>().ReverseMap();

            Mapper.CreateMap<IRedCross, RedCrossModel>().ReverseMap();
            Mapper.CreateMap<RedCross, RedCrossModel>().ReverseMap();
        }
    }
}