namespace Manga.Domain.Accounts
{
    using System.Collections.Generic;
    using Manga.Domain.ValueObjects;

    public interface IAccount : IAggregateRoot
    {
        IReadOnlyCollection<ICredit> GetCredits();
        IReadOnlyCollection<IDebit> GetDebits();
        ICredit Deposit(PositiveAmount amount);
        IDebit Withdraw(PositiveAmount amount);
        bool IsClosingAllowed();
        Amount GetCurrentBalance();
    }
}