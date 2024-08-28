using RestEase;

namespace Account.Ledger.Api.Services.Http
{
    [AllowAnyStatusCode]
    public interface IAccountLedgerFunctions
    {
        [Post("account-balance-updater")]
        Task<HttpResponseMessage> TriggerUpdaterFunction();
    }
}