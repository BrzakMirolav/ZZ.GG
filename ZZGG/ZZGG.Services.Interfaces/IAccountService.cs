using DataModel;
using System.Threading.Tasks;

namespace ZZGG.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAccountDetailsBySummonerName(string summonersName);
        Task<Account> GetAccountDetailsByAccountId(string accountId);
        Task<Account> GetChampionScoreBySummonerIdAndChampionId(int championId, string summonersName);
    }
}
