using BusinessModel;
using BusinessModel.GlobalModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ZZGG.BusinessLogic.Interfaces
{
    public interface IAccountBusinessLogic
    {
        Task<ApiResponse<Account>> GetAccountDetailsBySummonerName(string summonerName);
        Task<Account> GetAccountDetailsByAccountId(string accountId);
        Task<AccountChampionStats> GetChampionScoreBySummonerIdAndChampionId(string summonerId, int championId);
        Task<IEnumerable<AccountChampionStats>> GetAllChampionScoreBySummonerId(string summonerId);
        Task<TotalMasteryScore> GetAccountTotalMasteryLevel(string summonerId);
        Task<LoLVersion> GetVersion();
        Task<ImageUrl> GetIconByVersionAndIconId(int iconId);
        Task<IEnumerable<Champion>> GetAllChampions();
        Task<Champion> GetChampionById(int championId);
    }
}
