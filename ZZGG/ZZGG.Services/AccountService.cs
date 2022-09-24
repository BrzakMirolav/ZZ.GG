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
        private readonly string _getAccountTotalMasteryLevel;
        private readonly string _getAllChampionScoreBySummonerId;

        private readonly string _dDragonBaseAddress;
        private readonly string _getVersions;
        private readonly string _getIconByVersionAndIconID;





        public AccountService(IConfiguration config)
        {
            _config = config;
            _riotKey = _config["RIOTKEY"];
            _lolApiBaseAddress = _config["LoLAPIBaseAddress"];
            _getSummonerBySummonerNameMethod = _config["LoLAPIMethods:GetSummonerBySummonerName"];
            _getSummonerByAccountId = _config["LoLAPIMethods:GetSummonerByAccountId"];
            _getChampionScoreBySummonerIdAndChampionId = _config["LoLAPIMethods:GetChampionScoreBySummonerIdAndChampionId"];
            _getAccountTotalMasteryLevel = _config["LoLAPIMethods:GetAccountTotalMasteryLevel"];
            _getAllChampionScoreBySummonerId = _config["LoLAPIMethods:GetAllChampionScoreBySummonerId"];

            _dDragonBaseAddress = _config["DDragonBaseAddress"];
            _getVersions = _config["DDragonAPIMethods:GetVersions"]; 
            _getIconByVersionAndIconID = _config["DDragonAPIMethods:GetIconByVersionAndIconID"];
        }

        public async Task<Account> GetAccountDetailsBySummonerName(string summonerName)
        {
            HttpClient client = new HttpClient();
            var account = new Account();
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotKey);
            client.BaseAddress = new Uri(_lolApiBaseAddress);

            var response = await client.GetAsync(string.Format(_getSummonerBySummonerNameMethod ,summonerName));

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

        public async Task<AccountChampionStats> GetChampionScoreBySummonerIdAndChampionId(string summonerId, int championId)
        {
            HttpClient client = new HttpClient();
            var accountChampionStats = new AccountChampionStats();
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotKey);
            client.BaseAddress = new Uri(_lolApiBaseAddress);


            var response = await client.GetAsync(string.Format(_getChampionScoreBySummonerIdAndChampionId, summonerId, championId));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializedResponse = JsonConvert.DeserializeObject<AccountChampionStats>(content);

                if (serializedResponse == null)
                {
                    return new AccountChampionStats();
                }
                accountChampionStats = serializedResponse;

            }

            return accountChampionStats;
            
        }

        public async Task<IEnumerable<AccountChampionStats>> GetAllChampionScoreBySummonerId(string summonerId)
        {
            HttpClient client = new HttpClient();
            var accountChampionsStats = new List<AccountChampionStats>();
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotKey);
            client.BaseAddress = new Uri(_lolApiBaseAddress);


            var response = await client.GetAsync(string.Format(_getAllChampionScoreBySummonerId, summonerId));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializedResponse = JsonConvert.DeserializeObject<IEnumerable<AccountChampionStats>>(content);

                if (serializedResponse == null)
                {
                    return accountChampionsStats;
                }
                accountChampionsStats = (List<AccountChampionStats>)serializedResponse;

            }

            return accountChampionsStats;

        }


        public async Task<int> GetAccountTotalMasteryLevel(string summonerId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotKey);
            client.BaseAddress = new Uri(_lolApiBaseAddress);
            var accountMasteryLevel = 0;

            var response = await client.GetAsync(string.Format(_getAccountTotalMasteryLevel, summonerId));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                accountMasteryLevel = Convert.ToInt32(content);

            }

            return accountMasteryLevel;
        }

        public async Task<string> GetVersion()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotKey);
            client.BaseAddress = new Uri(_dDragonBaseAddress);
            var version = "";

            var response = await client.GetAsync(string.Format(_getVersions));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializedResponse = JsonConvert.DeserializeObject<IEnumerable<string>>(content);
                version = ((List<string>)serializedResponse)[0];

            }

            return version;
        }

        public async Task<string> GetIconByVersionAndIconId(int iconId)
        {
            
            var iconImage = "";

            var version = await GetVersion();
            var icon = iconId.ToString() + ".png";

            iconImage = _dDragonBaseAddress + string.Format( _getIconByVersionAndIconID, version, icon);

            return iconImage;
        }
    }
}
