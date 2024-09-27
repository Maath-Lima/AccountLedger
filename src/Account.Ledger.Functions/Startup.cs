using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

[assembly: FunctionsStartup(typeof(Account.Ledger.Functions.Startup))]
namespace Account.Ledger.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger());
            });
        }
    }
}
