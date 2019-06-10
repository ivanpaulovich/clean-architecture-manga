namespace Manga.Application.Boundaries.GetCustomerDetails
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.Customers;

    public sealed class Output
    {
        public Guid CustomerId { get; }
        public string Personnummer { get; }
        public string Name { get; }
        public IReadOnlyList<Account> Accounts { get; }

        public Output(
            ICustomer customer,
            List<Account> accounts)
        {
            Customer customerEntity = (Customer) customer;
            CustomerId = customerEntity.Id;
            Personnummer = customerEntity.SSN;
            Name = customerEntity.Name;
            Accounts = accounts;
        }
    }
}