﻿using Account.Ledger.Api.Models.Constants;

namespace Account.Ledger.Api.Models.Entities
{
    public class Transaction : Entity
    {
        public string AccountId { get; set; }
        public DateTime Date { get; }
        public int Amount { get; set; }
        public char Type { get; set; }

        public Transaction()
        {
            Date = DateTime.UtcNow;
        }

        public override bool EntityValidation() =>
            !string.IsNullOrWhiteSpace(AccountId)
            && Amount > 0
            && AccountLedgerConstants.TransactionsTypes.Contains(Type);
    }
}
