namespace Domain.Accounts
{
    using System;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;

    public interface IAccountFactory
    {
        IAccount NewAccount(ICustomer customer);

        ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate);

        IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate);
    }
}
