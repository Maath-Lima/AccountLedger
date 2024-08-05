using System.Diagnostics;

namespace Account.Ledger.Api.Models.Base.Responses
{
    public abstract class BaseResponse
    {
        public string TraceId { get; set; }

        public int StatusCode { get; set; };

        public BaseResponse()
        {
            TraceId = Activity.Current?.Id ?? Guid.NewGuid().ToString();
        }
    }
}
