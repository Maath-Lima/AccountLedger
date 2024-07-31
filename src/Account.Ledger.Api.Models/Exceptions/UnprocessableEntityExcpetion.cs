namespace Account.Ledger.Api.Models.Exceptions
{
    public class UnprocessableEntityExcpetion : Exception
    {
        public UnprocessableEntityExcpetion(string? message) : base(message)
        {
        }

        public UnprocessableEntityExcpetion(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
