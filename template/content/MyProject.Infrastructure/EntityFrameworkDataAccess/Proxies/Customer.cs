namespace MyProject.Infrastructure.EntityFrameworkDataAccess.Proxies
{
    using System;
    using System.Collections.Generic;
    using MyProject.Domain.Customers;

    public class Customer : Domain.Customers.Customer
    {
        public Customer(Domain.Customers.Customer customer, IEnumerable<Guid> accounts)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.PIN = customer.PIN;
            this.Accounts = new AccountCollection(accounts);
            this.Version = customer.Version;
        }
    }
}
