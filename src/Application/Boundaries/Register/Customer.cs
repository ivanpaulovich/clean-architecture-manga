namespace Application.Boundaries.Register
{
    using System.Collections.Generic;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public sealed class Customer
    {
        public Customer(
            ExternalUserId externalUserId,
            ICustomer customer,
            List<Account> accounts)
        {
            ExternalUserId = externalUserId;
            var customerEntity = (Domain.Customers.Customer)customer;
            CustomerId = customerEntity.Id;
            SSN = customerEntity.SSN;
            Name = customerEntity.Name;
            Accounts = accounts;
        }

        public ExternalUserId ExternalUserId { get; }

        public CustomerId CustomerId { get; }

        public SSN SSN { get; }

        public Name Name { get; }

        public IReadOnlyList<Account> Accounts { get; }
    }
}
