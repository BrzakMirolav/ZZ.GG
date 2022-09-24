using AutoMapper;
using BusinessModel;
using Microsoft.Extensions.Logging;
using ZZGG.BusinessLogic.Interfaces;
using ZZGG.Services.Interfaces;

namespace ZZGG.BusinessLogic
{
    public class AccountBusinessLogic: IAccountBusinessLogic
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

        public async Task<Account> GetAccountDetailsBySummonerName(string summonersName)
        {
            try
            {
                var result = new Account();

                var serviceResult = await _accountService.GetAccountDetailsBySummonerName(summonersName);

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
            catch(Exception ex)
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
                return new Account();
            }
        }
    }
}
