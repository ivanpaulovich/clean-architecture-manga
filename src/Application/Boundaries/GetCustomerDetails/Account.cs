// <copyright file="Account.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetCustomerDetails
{
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Account.
    /// </summary>
    public sealed class Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="account">Account object.</param>
        public Account(IAccount account)
        {
            var accountEntity = (Domain.Accounts.Account)account;

            this.AccountId = account.Id;
            this.CurrentBalance = account.GetCurrentBalance();

            var transactionResults = new List<Transaction>();
            foreach (var credit in accountEntity.Credits.GetTransactions())
            {
                var creditEntity = (Credit)credit;

                var transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity.Amount,
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (var debit in accountEntity.Debits.GetTransactions())
            {
                var debitEntity = (Debit)debit;

                var transactionOutput = new Transaction(
                    debitEntity.Description,
                    debitEntity.Amount,
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            this.Transactions = transactionResults;
        }

        /// <summary>
        /// Gets the Account Id.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        /// Gets the Current Balance.
        /// </summary>
        public Money CurrentBalance { get; }

        /// <summary>
        /// Gets the Transactions List.
        /// </summary>
        public List<Transaction> Transactions { get; }
    }
}
