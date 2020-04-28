// <copyright file="Debit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Entities
{
    using System;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Debit.
    /// </summary>
    public sealed class Debit : Domain.Accounts.Debits.Debit
    {
        public Debit()
        {
        }

        public Debit(DebitId id, AccountId accountId, PositiveMoney amount, DateTime transactionDate)
        {
            this.Id = id;
            this.AccountId = accountId;
            this.Amount = amount;
            this.TransactionDate = transactionDate;
        }

        /// <summary>
        ///     Gets or sets AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        public override PositiveMoney Amount { get; }

        public override DebitId Id { get; }

        public override DateTime TransactionDate { get; }
    }
}
