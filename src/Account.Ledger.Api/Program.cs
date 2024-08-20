using Account.Ledger.Api.Config.Mappings;
using Account.Ledger.Api.Extensions;
using Account.Ledger.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(TransactionsProfile));

builder.Services.AddExceptionHandler<BadRequestExceptionHandler>()
                .AddExceptionHandler<UnprocessableEntityExceptionHandler>()
                .AddExceptionHandler<ApiExceptionHandler>()
                .AddExceptionHandler<GlobalExceptionMiddleware>();

IConfiguration configuration = builder.Configuration;

builder.Services.RegisterServiceCollection(configuration);
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.RegisterTransactionsEndpoints();

app.Run();


//using Microsoft.Azure.WebJobs;

//namespace Account.Ledger.Functions.Functions
//{
//    public static class TransactionsFunctions
//    {
//        [FunctionName("account-balance-updater")]
//    }
//}
