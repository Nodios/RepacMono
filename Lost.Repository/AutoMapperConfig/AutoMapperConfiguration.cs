using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lost.DAL;
using Lost.DAL.Models;
using Lost.Model;
using Lost.Model.Common;
using Lost.Repository.Common;
using AutoMapper;

namespace Lost.Repository
{
    public class AutoMapperConfiguration : Profile
    {
        protected override void Configure()
        {
            //                             SOURCE         DESTINATION
            AutoMapper.Mapper.CreateMap<LostPersonEntity, LostPerson>().ReverseMap();
            AutoMapper.Mapper.CreateMap<LostPersonEntity, ILostPerson>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ILostPerson, LostPerson>().ReverseMap();

            AutoMapper.Mapper.CreateMap<RedCrossEntity, RedCross>().ReverseMap();
            AutoMapper.Mapper.CreateMap<RedCrossEntity, IRedCross>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IRedCross, RedCross>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ApplicationUserEntity, ApplicationUser>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ApplicationUserEntity, IApplicationUser>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IApplicationUser, ApplicationUser>().ReverseMap();
        }
        
        //public override string ProfileName
        //{
        //    get
        //    {
        //        return this.GetType().Name;
        //    }
        //}
    }
}
