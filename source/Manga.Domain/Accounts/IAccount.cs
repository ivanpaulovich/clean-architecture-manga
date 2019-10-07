namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;

    public interface IAccount : IAggregateRoot
    {
        ICredit Deposit(IEntityFactory entityFactory, PositiveMoney amountToDeposit);
        IDebit Withdraw(IEntityFactory entityFactory, PositiveMoney amountToWithdraw);
        bool IsClosingAllowed();
        Money GetCurrentBalance();
    }
}
