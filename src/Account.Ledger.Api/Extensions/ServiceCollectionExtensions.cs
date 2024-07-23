using Account.Ledger.Api.Config.Mappings;

namespace Account.Ledger.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServiceCollection(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TransactionsProfile));
        }
    }
}
