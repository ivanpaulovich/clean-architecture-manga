namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Customers;

    public class Account : Domain.Accounts.Account
    {
        public Account(ICustomer customer)
        {
            Id = Guid.NewGuid();
            CustomerId = customer.Id;
        }

        protected Account()
        {
        }

        public Guid CustomerId { get; protected set; }

        public void Load(IList<Credit> credits, IList<Debit> debits)
        {
            Credits = new CreditsCollection();
            Credits.Add(credits);

            Debits = new DebitsCollection();
            Debits.Add(debits);
        }
    }
}
