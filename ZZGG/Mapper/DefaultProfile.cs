using AutoMapper;
using BusinessModel;
using DataModel;

namespace Mapper
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<DataModel.Account, BusinessModel.Account>().ReverseMap()
                .ForMember(dest => dest.Id, m => m.MapFrom(source => source.Id))
                .ForMember(dest => dest.AccountId, m => m.MapFrom(source => source.AccountId))
                .ForMember(dest => dest.PuuId, m => m.MapFrom(source => source.PuuId))
                .ForMember(dest => dest.Name, m => m.MapFrom(source => source.Name))
                .ForMember(dest => dest.ProfileIconId, m => m.MapFrom(source => source.ProfileIconId))
                .ForMember(dest => dest.RevisionDate, m => m.MapFrom(source => source.RevisionDate))
                .ForMember(dest => dest.SummonerLevel, m => m.MapFrom(source => source.SummonerLevel))
                ;


            CreateMap<DataModel.AccountChampionStats, BusinessModel.AccountChampionStats>().ReverseMap()
               .ForMember(dest => dest.ChampionId, m => m.MapFrom(source => source.ChampionId))
               .ForMember(dest => dest.ChampionLevel, m => m.MapFrom(source => source.ChampionLevel))
               .ForMember(dest => dest.ChampionPoints, m => m.MapFrom(source => source.ChampionPoints))
               .ForMember(dest => dest.LastPlayTime, m => m.MapFrom(source => source.LastPlayTime))
               .ForMember(dest => dest.ChampionPointsSinceLastLevel, m => m.MapFrom(source => source.ChampionPointsSinceLastLevel))
               .ForMember(dest => dest.ChampionPointsUntilNextLevel, m => m.MapFrom(source => source.ChampionPointsUntilNextLevel))
               .ForMember(dest => dest.ChestGranted, m => m.MapFrom(source => source.ChestGranted))
               .ForMember(dest => dest.TokensEarned, m => m.MapFrom(source => source.TokensEarned))
               .ForMember(dest => dest.SummonerId, m => m.MapFrom(source => source.SummonerId))
               ;



        }
    }
}
