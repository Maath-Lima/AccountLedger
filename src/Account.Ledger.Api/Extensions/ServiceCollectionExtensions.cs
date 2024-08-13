using Account.Ledger.Api.Config.Mappings;
using Account.Ledger.Api.Models.Settings;
using Account.Ledger.Api.Services;
using Account.Ledger.Api.Services.Http;
using Account.Ledger.Api.Services.Interfaces;
using RestEase;

namespace Account.Ledger.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string AZURE_FUNCTIONS_SETTINGS = "AzureFunctionsSettings";
        private const int DEFAULT_TIMEOUT = 30;

        public static void RegisterServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(TransactionsProfile));
            services.AddScoped<IAccountBalanceServices, AccountBalanceServices>();

            // Settings
            var azureFunctionsSettings = configuration.GetSection(AZURE_FUNCTIONS_SETTINGS).Get<AzureFunctionsSettings>();

            // HTTP Clients
            ConfigureAzureFunctionsProjectHttpClient(services, azureFunctionsSettings);
        }

        private static void ConfigureAzureFunctionsProjectHttpClient(IServiceCollection services, AzureFunctionsSettings azureFunctionsSettings)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(azureFunctionsSettings.BaseURL, UriKind.Absolute),
                Timeout = TimeSpan.FromSeconds(DEFAULT_TIMEOUT)
            };

            services.AddSingleton(RestClient.For<IAccountLedgerFunctions>(httpClient));
        }
    }
}
