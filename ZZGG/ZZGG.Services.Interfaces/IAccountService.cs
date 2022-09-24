using DataModel;
using System.Threading.Tasks;

namespace ZZGG.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAccountDetailsBySummonerName(string summonersName);
        Task<Account> GetAccountDetailsByAccountId(string accountId);
        Task<AccountChampionStats> GetChampionScoreBySummonerIdAndChampionId(string summonerId, int championId);
        Task<IEnumerable<AccountChampionStats>> GetAllChampionScoreBySummonerId(string summonerId);
        Task<int> GetAccountTotalMasteryLevel(string summonerId);
        Task<string> GetVersion();
        Task<string> GetIconByVersionAndIconId(int iconId);
    }
}
