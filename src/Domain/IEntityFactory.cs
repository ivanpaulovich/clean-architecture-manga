namespace Domain
{
    using System;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Users;
    using Domain.ValueObjects;

    public interface IEntityFactory
    {
        IUser NewUser(ICustomer customer, ExternalUserId externalUserId);

        ICustomer NewCustomer(SSN ssn, Name name);

        IAccount NewAccount(ICustomer customer);

        ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate);

        IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate);
    }
}