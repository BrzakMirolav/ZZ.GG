using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using ZZGG.BusinessLogic.Interfaces;

namespace ZZGG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZZGGController : ControllerBase
    { 
        private readonly ILogger<ZZGGController> _logger;
        private readonly IAccountBusinessLogic _accountBL;
        public ZZGGController(ILogger<ZZGGController> logger, IAccountBusinessLogic accountBL)
        {
            _logger = logger;
            _accountBL = accountBL;
        }

        [HttpGet("GetAccountDetailsBySummonersName")]
        public async Task<IActionResult> GetAccountDetailsBySummonerNameAsync(string summonerName)
        {
            return Ok(await _accountBL.GetAccountDetailsBySummonerName(summonerName));
        }

        [HttpGet("GetAccountDetailsByAccountId")]
        public async Task<IActionResult> GetAccountDetailsByAccountId(string accountId)
        {
            return Ok(await _accountBL.GetAccountDetailsByAccountId(accountId));
        }

        [HttpGet("GetChampionScoreBySummonerIdAndChampionId")]
        public async Task<IActionResult> GetChampionScoreBySummonerIdAndChampionId(string summonerId, int championId)
        {
            return Ok(await _accountBL.GetChampionScoreBySummonerIdAndChampionId(summonerId, championId));
        }
    }
}