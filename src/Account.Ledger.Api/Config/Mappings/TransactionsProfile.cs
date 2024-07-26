using Account.Ledger.Api.Models.Constants;
using Account.Ledger.Api.Models.DTOs;
using Account.Ledger.Api.Models.Entities;
using AutoMapper;

namespace Account.Ledger.Api.Config.Mappings
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<TransactionRequest, Transaction>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom((src, dest, destMember, context) => context.Items[AccountLedgerConstants.ACCOUNT_ITEM]))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
        }
    }
}
