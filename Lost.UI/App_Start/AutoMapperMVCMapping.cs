using AutoMapper;
using Lost.Model;
using Lost.Model.Common;
using Lost.UI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.UI.App_Start
{
    public class AutoMapperMVCMapping : Profile
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