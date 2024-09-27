using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Serilog;

namespace Account.Ledger.Jobs
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILogger logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.Information("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
