namespace Application.Boundaries.CloseAccount
{
    using System;
    using Domain.Accounts;

    public sealed class CloseAccountOutput : IUseCaseOutput
    {
        public CloseAccountOutput(IAccount account)
        {
            AccountId = account.Id;
        }

        public Guid AccountId { get; }
    }
}
