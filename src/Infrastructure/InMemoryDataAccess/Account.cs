// <copyright file="Account.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    public class Account : Domain.Accounts.Account
    {
        public Account(CustomerId customerId)
        {
            this.Id = new AccountId(Guid.NewGuid());
            this.CustomerId = customerId;
        }

        protected Account()
        {
        }

        public CustomerId CustomerId { get; protected set; }

        public void Load(IList<Credit> credits, IList<Debit> debits)
        {
            this.Credits = new CreditsCollection();
            this.Credits.Add(credits);

            this.Debits = new DebitsCollection();
            this.Debits.Add(debits);
        }
    }
}
