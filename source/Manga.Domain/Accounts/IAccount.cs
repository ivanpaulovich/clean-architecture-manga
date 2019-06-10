namespace Manga.Domain.Accounts
{
    using System.Collections.Generic;
    using Manga.Domain.ValueObjects;

    public interface IAccount : IAggregateRoot
    {
        IReadOnlyCollection<ICredit> GetCredits();
        IReadOnlyCollection<IDebit> GetDebits();
        ICredit Deposit(Amount amount);
        IDebit Withdraw(Amount amount);
        bool CanBeClosed();
        Amount GetCurrentBalance();
    }
}