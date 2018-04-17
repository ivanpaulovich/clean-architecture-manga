namespace MyProject.Infrastructure.DapperDataAccess.Proxies
{
    using MyProject.Domain.Customers;
    using System;
    using System.Collections.Generic;

    internal class Customer : Domain.Customers.Customer
    {
        public Customer()
        {

        }

        public void SetAccounts(IEnumerable<Guid> accounts)
        {
            this.Accounts = new AccountCollection(accounts);
        }
    }
}
