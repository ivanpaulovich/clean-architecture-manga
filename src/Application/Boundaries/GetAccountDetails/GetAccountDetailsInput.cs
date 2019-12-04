namespace Application.Boundaries.GetAccountDetails
{
    using Domain.Accounts.ValueObjects;

    public sealed class GetAccountDetailsInput : IUseCaseInput
    {
        public GetAccountDetailsInput(AccountId accountId)
        {
            AccountId = accountId;
        }

        public AccountId AccountId { get; }
    }
}
