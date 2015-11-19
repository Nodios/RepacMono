using AutoMapper;
using Lost.Model;
using Lost.Model.Common;
using Lost.UI.Models;


namespace Lost.UI.App_Start
{
    public class MvcLayerMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ILostPerson, LostPersonModel>().ReverseMap();
            Mapper.CreateMap<LostPerson, LostPersonModel>().ReverseMap();
        }
    }
}