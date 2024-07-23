using System.Text.Json.Serialization;
using Account.Ledger.Api.Models.Entities;

namespace Account.Ledger.Api.Models.DTOs
{
    public class TransactionRequest
    {
        public int Value { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter<TransactionType>))]
        public TransactionType Type { get; set; }
    }
}
