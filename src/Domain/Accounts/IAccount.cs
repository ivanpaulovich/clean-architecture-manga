namespace Domain.Accounts
{
    using Domain.ValueObjects;

    public interface IAccount
    {
        AccountId Id { get; }

        ICredit Deposit(IEntityFactory entityFactory, PositiveMoney amountToDeposit);

        IDebit Withdraw(IEntityFactory entityFactory, PositiveMoney amountToWithdraw);

        bool IsClosingAllowed();

        Money GetCurrentBalance();
    }
}