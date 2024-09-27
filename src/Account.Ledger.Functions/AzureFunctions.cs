using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Serilog;
using System.Threading.Tasks;

namespace Account.Ledger.Functions
{
    public static class AzureFunctions
    {
        [FunctionName("account-balance-updater")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "account-balance-updater")] HttpRequest req,
            ILogger logger)
        {
            logger.Information("Log Test");
            return new OkObjectResult("Function triggred!!!");
        }
    }
}
