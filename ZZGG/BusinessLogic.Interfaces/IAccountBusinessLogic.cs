﻿using BusinessModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ZZGG.BusinessLogic.Interfaces
{
    public interface IAccountBusinessLogic
    {
        Task<Account> GetAccountDetailsBySummonerName(string summonerName);
        Task<Account> GetAccountDetailsByAccountId(string accountId);
        Task<AccountChampionStats> GetChampionScoreBySummonerIdAndChampionId(string summonerId, int championId);
        Task<IEnumerable<AccountChampionStats>> GetAllChampionScoreBySummonerId(string summonerId);
        Task<int> GetAccountTotalMasteryLevel(string summonerId);
        Task<string> GetVersion();
        Task<string> GetIconByVersionAndIconId(int iconId);
    }
}
