using Account.Ledger.Api.Models;
using Account.Ledger.Api.Models.Constants;
using Account.Ledger.Api.Models.DTOs;
using Account.Ledger.Api.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Account.Ledger.Api.Extensions
{
    public static class TransactionsEndpoints
    {
        private const string TRANSACTIONS_BASE_ENDPOINT = "/api/transactions";
        private const string ACCOUNT_BASE_ENDPOINT = "/api/account";

        public static void RegisterTransactionsEndpoints(this WebApplication app)
        {
            var transactionBase = app.MapGroup(TRANSACTIONS_BASE_ENDPOINT);

            transactionBase.MapPost("/", PostTransactionsByAccount);
            //transactionBase.MapGet("/{transactionId}", GetTransactionsByAccount);

            //transactionBase.MapGet($"{ACCOUNT_BASE_ENDPOINT}/{{accountId}}", GetAccount);
        }

        static async Task PostTransactionsByAccount(
            [FromHeader(Name = "Account")] Guid accountId,
            TransactionRequest transactionRequest,
            IMapper mapper)
        {
            if (accountId == null || accountId == Guid.Empty)
            {
                TypedResults.BadRequest(new BaseResponse<object>(["missing transaction account..."]));
            }

            var transaction = mapper.Map<Transaction>(transactionRequest, opt => opt.Items[AccountLedgerConstants.ACCOUNT_ITEM] = accountId);

            if (transaction.EntityValidation())
            {
                TypedResults.UnprocessableEntity(new BaseResponse<object>(["invalid entity..."]));
            };

            throw new NotImplementedException();
        }
    }
}
