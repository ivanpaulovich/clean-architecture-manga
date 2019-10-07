namespace Manga.Infrastructure.EntityFrameworkDataAccess
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;

    public class Account : Manga.Domain.Accounts.Account
    {
        public Guid CustomerId { get; protected set; }

        protected Account() { }

        public Account(ICustomer customer)
        {
            Id = Guid.NewGuid();
            CustomerId = customer.Id;
        }

        public void Load(IList<Credit> credits, IList<Debit> debits)
        {
            Credits = new CreditsCollection();
            Credits.Add(credits);

            Debits = new DebitsCollection();
            Debits.Add(debits);
        }
    }
}
