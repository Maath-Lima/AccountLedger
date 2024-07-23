using Account.Ledger.Api.Config.Mappings;
using Account.Ledger.Api.Extensions;
using Account.Ledger.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(TransactionsProfile));

builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<UnprocessableEntityExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionMiddleware>();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.RegisterTransactionsEndpoints();

app.Run();
