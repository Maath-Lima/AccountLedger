namespace Account.Ledger.Api.Models.Base.Responses
{
    public class DataResponse<T> : BaseResponse where T : class
    {
        public T Data { get; set; }
    }
}
