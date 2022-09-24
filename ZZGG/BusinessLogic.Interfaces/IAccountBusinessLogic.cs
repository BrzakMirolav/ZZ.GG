using BusinessModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ZZGG.BusinessLogic.Interfaces
{
    public interface IAccountBusinessLogic
    {
        Task<Account> GetAccountDetailsBySummonerName(string summonersName);
        Task<Account> GetAccountDetailsByAccountId(string summonersName);
    }
}
