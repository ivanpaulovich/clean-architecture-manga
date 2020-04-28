// <copyright file="Credit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Entities
{
    using System;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Credit.
    /// </summary>
    public sealed class Credit : Domain.Accounts.Credits.Credit
    {
        public Credit()
        {
        }

        public Credit(CreditId id, AccountId accountId, PositiveMoney amount, DateTime transactionDate)
        {
            this.Id = id;
            this.AccountId = accountId;
            this.Amount = amount;
            this.TransactionDate = transactionDate;
        }

        public override CreditId Id { get; }

        /// <summary>
        ///     Gets or sets AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        public override PositiveMoney Amount { get; }

        public override DateTime TransactionDate { get; }
    }
}
