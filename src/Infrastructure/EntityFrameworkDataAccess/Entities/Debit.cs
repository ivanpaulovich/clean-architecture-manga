// <copyright file="Debit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess.Entities
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Debit.
    /// </summary>
    public class Debit : Domain.Accounts.Debits.Debit
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Debit" /> class.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <param name="amountToWithdraw">Amount to withdraw.</param>
        /// <param name="transactionDate">Transaction date.</param>
        public Debit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToWithdraw;
            this.TransactionDate = transactionDate;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Debit" /> class.
        /// </summary>
        protected Debit()
        {
        }

        /// <summary>
        ///     Gets or sets AccountId.
        /// </summary>
        public AccountId AccountId { get; protected set; }
    }
}
