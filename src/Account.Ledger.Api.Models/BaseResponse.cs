using System.Diagnostics;

namespace Account.Ledger.Api.Models
{
    public class BaseResponse<T> where T : class
    {
        public string TraceId { get; }
        public T Data { get; set; }
        public IList<string> Errors { get; set; }

        public BaseResponse(IList<string>? errors = default)
        {
            TraceId = Activity.Current?.Id ?? Guid.NewGuid().ToString();
            Errors = errors ?? [];
        }
    }
}
