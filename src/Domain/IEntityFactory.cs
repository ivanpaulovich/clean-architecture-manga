namespace Domain
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Customers;
    using Domain.Users;

    public interface IEntityFactory
    {
        IUser NewUser(ICustomer customer, ExternalUserId externalUserId);

        ICustomer NewCustomer(SSN ssn, Name name);

        IAccount NewAccount(ICustomer customer);

        ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate);

        IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate);
    }
}
