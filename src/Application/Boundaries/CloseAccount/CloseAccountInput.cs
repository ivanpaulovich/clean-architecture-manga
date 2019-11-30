namespace Application.Boundaries.CloseAccount
{
    using Domain.Accounts;

    public sealed class CloseAccountInput : IUseCaseInput
    {
        public CloseAccountInput(AccountId accountId)
        {
            AccountId = accountId;
        }

        public AccountId AccountId { get; }
    }
}
