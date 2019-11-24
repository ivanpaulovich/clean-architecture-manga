namespace Application.Boundaries.GetAccountDetails
{
    using Domain.ValueObjects;

    public sealed class GetAccountDetailsInput : IUseCaseInput
    {
        public GetAccountDetailsInput(AccountId accountId)
        {
            AccountId = accountId;
        }

        public AccountId AccountId { get; }
    }
}