namespace Acerola.Infrastructure.Mappings
{
    using Acerola.Application.Accounts.Details;
    using Acerola.Domain.Accounts;
    using AutoMapper;

    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, AccountData>()
                    .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CurrentBalance, opt => opt.MapFrom(src => src.CurrentBalance.Value))
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));

            CreateMap<Debit, TransactionData>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate));

            CreateMap<Credit, TransactionData>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate));
        }
    }
}
