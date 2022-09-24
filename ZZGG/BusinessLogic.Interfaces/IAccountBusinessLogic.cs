using BusinessModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ZZGG.BusinessLogic.Interfaces
{
    public interface IAccountBusinessLogic
    {
        Task<Account> GetAccountDetailsBySummonerName(string summonerName);
        Task<Account> GetAccountDetailsByAccountId(string accountId);
        Task<AccountChampionStats> GetChampionScoreBySummonerIdAndChampionId(string summonerId, int championId);
    }
}
