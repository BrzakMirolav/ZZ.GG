using AutoMapper;
using BusinessModel;
using DataModel;

namespace Mapper
{
    public class DefaultProfile: Profile
    {
        public DefaultProfile()
        {
            CreateMap<DataModel.Account, BusinessModel.Account>().ReverseMap()
                .ForMember(dest => dest.Id, m=>m.MapFrom(source=>source.Id))
                .ForMember(dest => dest.AccountId, m => m.MapFrom(source => source.AccountId))
                .ForMember(dest => dest.PuuId, m => m.MapFrom(source => source.PuuId))
                .ForMember(dest => dest.Name, m => m.MapFrom(source => source.Name))
                .ForMember(dest => dest.ProfileIconId, m => m.MapFrom(source => source.ProfileIconId))
                .ForMember(dest => dest.RevisionDate, m => m.MapFrom(source => source.RevisionDate))
                .ForMember(dest => dest.SummonerLevel, m => m.MapFrom(source => source.SummonerLevel))
                ;
        }
    }
}
