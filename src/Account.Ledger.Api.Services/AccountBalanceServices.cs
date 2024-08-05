using Account.Ledger.Api.Models.Base.Responses;
using Account.Ledger.Api.Services.Http;
using Account.Ledger.Api.Services.Interfaces;

namespace Account.Ledger.Api.Services
{
    public class AccountBalanceServices : BaseServices, IAccountBalanceServices
    {
        private readonly IAccountLedgerFunctions _azureFunctions;

        public AccountBalanceServices(IAccountLedgerFunctions azureFunctions)
        {
            _azureFunctions = azureFunctions;
        }

        public async Task<BaseResponse> TriggerBalanceUpdateAsync()
        {
            var response = await _azureFunctions.TriggerUpdaterFunction();

            if (!response.IsSuccessStatusCode)
            {
                await HandleUnsuccessfulResponseAsync(response);
            }

            return default;
        }
    }
}
