// <copyright file="Account.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Entities
{
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    /// <inheritdoc />
    public sealed class Account : Domain.Accounts.Account
    {
        public Account()
        {
        }

        public Account(AccountId id, CustomerId customerId)
        {
            this.Id = id;
            this.CustomerId = customerId;
        }

        /// <inheritdoc />
        public override CreditsCollection Credits { get; } = new CreditsCollection();

        /// <inheritdoc />
        public override DebitsCollection Debits { get; } = new DebitsCollection();

        /// <inheritdoc />
        public override AccountId Id { get; }

        /// <summary>
        ///     Gets or sets CustomerId.
        /// </summary>
        public CustomerId CustomerId { get; }
    }
}
