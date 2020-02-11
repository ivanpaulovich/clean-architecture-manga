// <copyright file="Account.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetCustomerDetails
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Account.
    /// </summary>
    public sealed class Account
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        /// <param name="account">Account object.</param>
        public Account(IAccount account)
        {
            if (account is Domain.Accounts.Account accountEntity)
            {
                this.AccountId = accountEntity.Id;
                this.CurrentBalance = accountEntity.GetCurrentBalance();

                var transactionResults = new List<Transaction>();
                foreach (var credit in accountEntity.Credits.GetTransactions())
                {
                    if (credit is Credit creditEntity)
                    {
                        var transactionOutput = new Transaction(
                            Credit.Description,
                            creditEntity.Amount,
                            creditEntity.TransactionDate);

                        transactionResults.Add(transactionOutput);
                    }
                }

                foreach (var debit in accountEntity.Debits.GetTransactions())
                {
                    if (debit is Debit debitEntity)
                    {
                        var transactionOutput = new Transaction(
                            Debit.Description,
                            debitEntity.Amount,
                            debitEntity.TransactionDate);

                        transactionResults.Add(transactionOutput);
                    }
                }

                this.Transactions = transactionResults;
            }
            else
                throw new ArgumentNullException(nameof(account));
        }

        /// <summary>
        ///     Gets the Account Id.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        ///     Gets the Current Balance.
        /// </summary>
        public Money CurrentBalance { get; }

        /// <summary>
        ///     Gets the Transactions List.
        /// </summary>
        public List<Transaction> Transactions { get; }
    }
}
