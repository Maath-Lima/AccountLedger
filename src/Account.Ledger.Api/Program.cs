using Account.Ledger.Api.Config.Mappings;
using Account.Ledger.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(TransactionsProfile));

var app = builder.Build();

app.UseHttpsRedirection();


app.RegisterTransactionsEndpoints();

app.Run();
