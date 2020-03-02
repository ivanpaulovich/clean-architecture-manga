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

    public sealed class Account : Domain.Accounts.Account
    {
        public Account(AccountId accountId, CustomerId customerId, IEnumerable<Credit> credits, IEnumerable<Debit> debits)
        {
            this.Id = accountId;
            this.CustomerId = customerId;

            this.Credits = new CreditsCollection();
            this.Credits.Add(credits);

            this.Debits = new DebitsCollection();
            this.Debits.Add(debits);
        }

        public CustomerId CustomerId { get; }
    }
}
