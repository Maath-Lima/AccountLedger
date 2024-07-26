namespace Account.Ledger.Api.Models.DTOs
{
    public class TransactionRequest
    {
        public int Value { get; set; }

        public char Type { get; set; }
    }
}
