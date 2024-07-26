using Account.Ledger.Api.Models.Constants;
using Account.Ledger.Api.Models.DTOs;
using Account.Ledger.Api.Models.Entities;
using Account.Ledger.Api.Models.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

        static async Task<Ok<Guid>> PostTransactionsByAccount(
            [FromHeader(Name = "account")] Guid accountId,
            TransactionRequest transactionRequest,
            IMapper mapper)
        {
            if (accountId == null || accountId == Guid.Empty)
            {
                throw new BadRequestException("missing transaction account...");
            }

            var transaction = mapper.Map<Transaction>(transactionRequest, opt => opt.Items[AccountLedgerConstants.ACCOUNT_ITEM] = accountId);

            if (!transaction.EntityValidation())
            {
                throw new UnprocessableEntityExcpetion("invalid entity...");
            };



            return TypedResults.Ok(transaction.Id);
        }
    }
}
