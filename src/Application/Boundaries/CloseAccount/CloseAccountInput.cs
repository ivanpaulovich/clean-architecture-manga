namespace Application.Boundaries.CloseAccount
{
    using Domain.ValueObjects;

    public sealed class CloseAccountInput : IUseCaseInput
    {
        public CloseAccountInput(AccountId accountId)
        {
            AccountId = accountId;
        }

        public AccountId AccountId { get; }
    }
}