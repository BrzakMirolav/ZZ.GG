using DataModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using ZZGG.Services.Interfaces;

namespace ZZGG.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _config;
        private readonly string _riotKey;
        private readonly string _lolApiBaseAddress;
        private readonly string _getSummonerBySummonerNameMethod;
        private readonly string _getSummonerByAccountId;
        private readonly string _getChampionScoreBySummonerIdAndChampionId;


        public AccountService(IConfiguration config)
        {
            _config = config;
            _riotKey = _config["RIOTKEY"];
            _lolApiBaseAddress = _config["LoLAPIBaseAdress"];
            _getSummonerBySummonerNameMethod = _config["LoLAPIMethods:GetSummonerBySummonerName"];
            _getSummonerByAccountId = _config["LoLAPIMethods:GetSummonerByAccountId"];
            _getChampionScoreBySummonerIdAndChampionId = _config["LoLAPIMethods:GetChampionScoreBySummonerIdAndChampionId"];
        }

        public async Task<Account> GetAccountDetailsBySummonerName(string summonersName)
        {
            HttpClient client = new HttpClient();
            var account = new Account();
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotKey);
            client.BaseAddress = new Uri(_lolApiBaseAddress);

            var x = "LO9OZTOdxQsJjW1Fsvi_iX1KIa5wGlI_LGZR5YOFEHgy-Io";
            var y = 238;

            var response = await client.GetAsync(string.Format(_getSummonerBySummonerNameMethod ,summonersName));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializedResponse = JsonConvert.DeserializeObject<Account>(content);

                if (serializedResponse == null)
                {
                    return new Account();
                }
                account = serializedResponse;
                
            }

            return account;

        }

        public async Task<Account> GetAccountDetailsByAccountId(string accountId)
        {
            HttpClient client = new HttpClient();
            var account = new Account();
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotKey);
            client.BaseAddress = new Uri(_lolApiBaseAddress);

            var response = await client.GetAsync(string.Format(_getSummonerByAccountId, accountId));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializedResponse = JsonConvert.DeserializeObject<Account>(content);

                if (serializedResponse == null)
                {
                    return new Account();
                }
                account = serializedResponse;

            }

            return account;

        }

        public async Task<Account> GetChampionScoreBySummonerIdAndChampionId(int championId, string summonersName)
        {
            HttpClient client = new HttpClient();
            var account = new Account();
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotKey);
            client.BaseAddress = new Uri(_lolApiBaseAddress + _getChampionScoreBySummonerIdAndChampionId);

            var x = "LO9OZTOdxQsJjW1Fsvi_iX1KIa5wGlI_LGZR5YOFEHgy-Io";
            var y = 238;

            var response = await client.GetAsync(string.Format(_lolApiBaseAddress + _getChampionScoreBySummonerIdAndChampionId, championId, summonersName));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializedResponse = JsonConvert.DeserializeObject<Account>(content);

                if (serializedResponse == null)
                {
                    return new Account();
                }
                account = serializedResponse;

            }

            return account;

        }
    }
}
