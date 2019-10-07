namespace Manga.Infrastructure.InMemoryDataAccess
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;
    using Manga.Domain;

    public sealed class EntityFactory : IEntityFactory
    {
        public IAccount NewAccount(ICustomer customer)
             => new Account(customer);

        public ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate)
            => new Credit(account, amountToDeposit, transactionDate);

        public ICustomer NewCustomer(SSN ssn, Name name)
            => new Customer(ssn, name);

        public IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate)
            => new Debit(account, amountToWithdraw, transactionDate);
    }
}
