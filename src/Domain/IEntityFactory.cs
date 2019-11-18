namespace Domain
{
    using System;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.ValueObjects;

    public interface IEntityFactory
    {
        ICustomer NewCustomer(ExternalUserId externalUserId, SSN ssn, Name name);

        IAccount NewAccount(ICustomer customer);

        ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate);

        IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate);
    }
}
