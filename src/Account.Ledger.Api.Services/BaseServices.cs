using RestEase;

namespace Account.Ledger.Api.Services
{
    public abstract class BaseServices
    {
        public async Task HandleUnsuccessfulResponseAsync(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();

            throw new ApiException(response.RequestMessage, response, body);
        }
    }
}
