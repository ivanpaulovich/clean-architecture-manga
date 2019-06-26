namespace Manga.Domain
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;

    public sealed class DefaultEntitiesFactory : IEntitiesFactory
    {
        public IAccount NewAccount(Guid customerId)
        {
            var account = new Account(customerId);
            return account;
        }

        public ICustomer NewCustomer(SSN ssn, Name name)
        {
            var customer = new Customer(ssn, name);
            return customer;
        }
    }
}