using BusinessModel;
using BusinessModel.GlobalModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
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

        /// <summary>
        /// Method returns account details for provided summoner name.
        /// </summary>
        /// <param name="summonerName"></param>
        /// <returns></returns>
        [HttpGet("GetAccountDetailsBySummonersName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Account>))]
        public async Task<IActionResult> GetAccountDetailsBySummonerName([FromServices]IAccountBusinessLogic _accBl, string summonerName) //Tested Methods Request with DI
        {
            return Ok(await _accBl.GetAccountDetailsBySummonerName(summonerName));
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

        [HttpGet("GetAllChampionScoreBySummonerId")]
        public async Task<IActionResult> GetAllChampionScoreBySummonerId(string summonerId)
        {
            return Ok(await _accountBL.GetAllChampionScoreBySummonerId(summonerId));
        }

        [HttpGet("GetAccountTotalMasteryLevel")]
        public async Task<IActionResult> GetAccountTotalMasteryLevel(string summonerId)
        {
            return Ok(await _accountBL.GetAccountTotalMasteryLevel(summonerId));
        }

        [HttpGet("GetVersion")]
        public async Task<IActionResult> GetVersion()
        {
            return Ok(await _accountBL.GetVersion());
        }


        [HttpGet("GetIconByVersionAndIconId")]
        public async Task<IActionResult> GetIconByVersionAndIconId(int iconId)
        {
             return Ok(await _accountBL.GetIconByVersionAndIconId(iconId));           
        }


        [HttpGet("GetAllChampions")]
        public async Task<IActionResult> GetAllChampions()
        {
            return Ok(await _accountBL.GetAllChampions());
        }

        [HttpGet("GetChampionById")]
        public async Task<IActionResult> GetChampionById(int championId)
        {
            return Ok(await _accountBL.GetChampionById(championId));
        }

    }
}