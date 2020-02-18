// <copyright file="Credit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess.Entities
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Credit.
    /// </summary>
    public class Credit : Domain.Accounts.Credits.Credit
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Credit" /> class.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <param name="amountToDeposit">Amount to Deposit.</param>
        /// <param name="transactionDate">Transaction Date.</param>
        public Credit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToDeposit;
            this.TransactionDate = transactionDate;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Credit" /> class.
        /// </summary>
        protected Credit()
        {
        }

        /// <summary>
        ///     Gets or sets AccountId.
        /// </summary>
        public AccountId AccountId { get; protected set; }
    }
}
