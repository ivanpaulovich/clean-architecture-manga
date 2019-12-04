namespace Application.Boundaries.CloseAccount
{
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    public sealed class CloseAccountOutput : IUseCaseOutput
    {
        public CloseAccountOutput(IAccount account)
        {
            AccountId = account.Id;
        }

        public AccountId AccountId { get; }
    }
}
