namespace Domain.Accounts
{
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;

    public interface IAccount
    {
        AccountId Id { get; }

        ICredit Deposit(IEntityFactory entityFactory, PositiveMoney amountToDeposit);

        IDebit Withdraw(IEntityFactory entityFactory, PositiveMoney amountToWithdraw);

        bool IsClosingAllowed();

        Money GetCurrentBalance();
    }
}
