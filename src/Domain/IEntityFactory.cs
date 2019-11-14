namespace Domain
{
    using System;
    using Accounts;
    using Customers;
    using ValueObjects;

    public interface IEntityFactory
    {
        ICustomer NewCustomer(SSN ssn, Name name, Username username, Password password);
        IAccount NewAccount(ICustomer customer);
        ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate);
        IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate);
    }
}
