namespace Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;

    public class Account : Domain.Accounts.Account
    {
        public Account(ICustomer customer)
        {
            Id = new AccountId(Guid.NewGuid());
            CustomerId = customer.Id;
        }

        protected Account()
        {
        }

        public CustomerId CustomerId { get; protected set; }

        public void Load(IList<Credit> credits, IList<Debit> debits)
        {
            Credits = new CreditsCollection();
            Credits.Add(credits);

            Debits = new DebitsCollection();
            Debits.Add(debits);
        }
    }
}
