namespace Domain.Accounts
{
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public interface IAccount
    {
        AccountId Id { get; }

        ICredit Deposit(IAccountFactory entityFactory, PositiveMoney amountToDeposit);

        IDebit Withdraw(IAccountFactory entityFactory, PositiveMoney amountToWithdraw);

        bool IsClosingAllowed();

        Money GetCurrentBalance();
    }
}
