namespace Application.Boundaries.Register
{
    using System.Collections.Generic;
    using System;
    using Domain.Customers;
    using Domain.ValueObjects;

    public sealed class Customer
    {
        public ExternalUserId ExternalUserId { get; }
        public Guid CustomerId { get; }
        public SSN SSN { get; }
        public Name Name { get; }
        public IReadOnlyList<Account> Accounts { get; }

        public Customer(
            ExternalUserId externalUserId,
            ICustomer customer,
            List<Account> accounts)
        {
            ExternalUserId = externalUserId;
            var customerEntity = (Domain.Customers.Customer) customer;
            CustomerId = customerEntity.Id;
            SSN = customerEntity.SSN;
            Name = customerEntity.Name;
            Accounts = accounts;
        }
    }
}