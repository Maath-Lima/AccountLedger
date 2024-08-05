using RestEase;

namespace Account.Ledger.Api.Services.Http
{
    [AllowAnyStatusCode]
    public interface IAccountLedgerFunctions
    {
        [Post("")]
        Task<HttpResponseMessage> TriggerUpdaterFunction();
    }
}