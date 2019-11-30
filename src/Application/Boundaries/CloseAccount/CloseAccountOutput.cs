namespace Application.Boundaries.CloseAccount
{
    using Domain.Accounts;

    public sealed class CloseAccountOutput : IUseCaseOutput
    {
        public CloseAccountOutput(IAccount account)
        {
            AccountId = account.Id;
        }

        public AccountId AccountId { get; }
    }
}
