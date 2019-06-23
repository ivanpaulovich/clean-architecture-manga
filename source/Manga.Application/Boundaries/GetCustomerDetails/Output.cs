namespace Manga.Application.Boundaries.GetCustomerDetails
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.Customers;

    public sealed class Output
    {
        public Guid CustomerId { get; }
        public string SSN { get; }
        public string Name { get; }
        public IReadOnlyList<Account> Accounts { get; }

        public Output(
            ICustomer customer,
            List<Account> accounts)
        {
            Customer customerEntity = (Customer) customer;
            CustomerId = customerEntity.Id;
            SSN = customerEntity.SSN.ToString();
            Name = customerEntity.Name.ToString();
            Accounts = accounts;
        }
    }
}