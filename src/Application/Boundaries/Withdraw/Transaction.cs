// <copyright file="Transaction.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Withdraw
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Transaction.
    /// </summary>
    public sealed class Transaction
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Transaction" /> class.
        /// </summary>
        /// <param name="description">Text description.</param>
        /// <param name="amount">Amount.</param>
        /// <param name="transactionDate">Transaction Date.</param>
        public Transaction(
            string description,
            PositiveMoney amount,
            DateTime transactionDate)
        {
            this.Description = description;
            this.Amount = amount;
            this.TransactionDate = transactionDate;
        }

        /// <summary>
        ///     Gets the Description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        public PositiveMoney Amount { get; }

        /// <summary>
        ///     Gets the Transaction Date.
        /// </summary>
        public DateTime TransactionDate { get; }
    }
}
