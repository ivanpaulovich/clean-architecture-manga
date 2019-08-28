namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;

    public interface IAccount : IAggregateRoot
    {
        ICredit Deposit(IEntityFactory entityFactory, PositiveAmount amountToDeposit);
        IDebit Withdraw(IEntityFactory entityFactory, PositiveAmount amountToWithdraw);
        bool IsClosingAllowed();
        Amount GetCurrentBalance();
    }
}