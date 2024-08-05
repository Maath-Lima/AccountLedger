using Account.Ledger.Api.Models.Base.Responses;

namespace Account.Ledger.Api.Services.Interfaces
{
    public interface IAccountBalanceServices
    {
        Task<BaseResponse> TriggerBalanceUpdateAsync();
    }
}
