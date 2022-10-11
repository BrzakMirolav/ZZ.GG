using AutoMapper;
using BusinessModel;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ZZGG.BusinessLogic.Interfaces;
using ZZGG.Services.Interfaces;

namespace ZZGG.BusinessLogic
{
    public class AccountBusinessLogic : IAccountBusinessLogic
    {
        private readonly ILogger<AccountBusinessLogic> _logger;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountBusinessLogic(ILogger<AccountBusinessLogic> logger, IAccountService accountService, IMapper mapper)
        {
            _logger = logger;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<Account> GetAccountDetailsBySummonerName(string summonerName)
        {
            try
            {
                var result = new Account();

                var serviceResult = await _accountService.GetAccountDetailsBySummonerName(summonerName);

                if (serviceResult == null)
                {
                    return result = new Account();
                }
                var mappedResult = _mapper.Map<Account>(serviceResult);

                if (mappedResult == null)
                {
                    return result = new Account();
                }
                result = mappedResult;
                return result;
            }
            catch (Exception ex)
            {
                return new Account();
            }
        }

        public async Task<Account> GetAccountDetailsByAccountId(string accountId)
        {
            try
            {
                var result = new Account();

                var serviceResult = await _accountService.GetAccountDetailsByAccountId(accountId);

                if (serviceResult == null)
                {
                    return result = new Account();
                }
                var mappedResult = _mapper.Map<Account>(serviceResult);

                if (mappedResult == null)
                {
                    return result = new Account();
                }
                result = mappedResult;
                return result;
            }
            catch (Exception ex)
            {
                return new Account()
                {
                    Id = ex.ToString()
                };
            }
        }

        public async Task<AccountChampionStats> GetChampionScoreBySummonerIdAndChampionId(string summonerId, int championId)
        {
            try
            {
                var result = new AccountChampionStats();

                var serviceResult = await _accountService.GetChampionScoreBySummonerIdAndChampionId(summonerId, championId);

                if (serviceResult == null)
                {
                    return result = new AccountChampionStats();
                }
                var mappedResult = _mapper.Map<AccountChampionStats>(serviceResult);

                if (mappedResult == null)
                {
                    return result = new AccountChampionStats();
                }
                result = mappedResult;
                return result;
            }
            catch (Exception ex)
            {
                return new AccountChampionStats()
                {
                    SummonerId = ex.ToString()
                };
            }
        }

        public async Task<IEnumerable<AccountChampionStats>> GetAllChampionScoreBySummonerId(string summonerId)
        {
            try
            {
                var result = new List<AccountChampionStats>();

                var serviceResult = await _accountService.GetAllChampionScoreBySummonerId(summonerId);

                if (serviceResult == null)
                {
                    return result;
                }
                var mappedResult = _mapper.Map<IEnumerable<AccountChampionStats>>(serviceResult);

                if (mappedResult == null)
                {
                    return result;
                }
                result = (List<AccountChampionStats>)mappedResult;
                return result;
            }
            catch (Exception ex)
            {
                var result = new List<AccountChampionStats>();
                return result;
            }
        }


        public async Task<TotalMasteryScore> GetAccountTotalMasteryLevel(string summonerId)
        {
            try
            {
                var result = new TotalMasteryScore();

                var serviceResult = await _accountService.GetAccountTotalMasteryLevel(summonerId);

                result.Score = serviceResult;

                return result;
            }
            catch (Exception ex)
            {
                return new TotalMasteryScore();
            }
        }

        public async Task<LoLVersion> GetVersion()
        {
            try
            {
                var result = new LoLVersion();

                var serviceResult = await _accountService.GetVersion();

                result.Version = serviceResult;

                return result;
            }
            catch (Exception ex)
            {
                return new LoLVersion();
            }
        }

        public async Task<ImageUrl> GetIconByVersionAndIconId(int iconId)
        {
            try
            {
                var result = new ImageUrl();

                var serviceResult = await _accountService.GetIconByVersionAndIconId(iconId);

                result.Url = serviceResult;

                return result;
            }
            catch (Exception ex)
            {
                return new ImageUrl();
            }
        }

        public async Task<IEnumerable<Champion>> GetAllChampions()
        {
            try
            {
                var result = new List<Champion>();

                var serviceResult = await _accountService.GetAllChampions();
                var mappedResult = _mapper.Map<IEnumerable<Champion>>(serviceResult);

                result = (List<Champion>)mappedResult;

                return result;
            }
            catch (Exception ex)
            {
                return new List<Champion>();
            }
        }

        

             public async Task<Champion> GetChampionById(int championId)
        {
            try
            {
                var result = new Champion();

                var serviceResult = await _accountService.GetChampionById(championId);
                var mappedResult = _mapper.Map<Champion>(serviceResult);

                result = mappedResult;

                return result;
            }
            catch (Exception ex)
            {
                return new Champion();
            }
        }

    }
}
