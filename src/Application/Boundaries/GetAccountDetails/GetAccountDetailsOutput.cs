// <copyright file="GetAccountDetailsOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.GetAccountDetails
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Get Account Details Output Message.
    /// </summary>
    public sealed class GetAccountDetailsOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountDetailsOutput" /> class.
        /// </summary>
        /// <param name="account">Account object.</param>
        public GetAccountDetailsOutput(IAccount account)
        {
            if (account is Account accountEntity)
            {
                this.AccountId = accountEntity.Id;
                this.CurrentBalance = accountEntity
                    .GetCurrentBalance();

                List<Transaction> transactionResults = new List<Transaction>();
                foreach (var credit in accountEntity.Credits
                    .GetTransactions())
                {
                    if (credit is Credit creditEntity)
                    {
                        Transaction transactionOutput = new Transaction(
                            Credit.Description,
                            creditEntity.Amount,
                            creditEntity.TransactionDate);

                        transactionResults.Add(transactionOutput);
                    }
                }

                foreach (var debit in accountEntity.Debits
                    .GetTransactions())
                {
                    if (debit is Debit debitEntity)
                    {
                        Transaction transactionOutput = new Transaction(
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
        ///     Gets the AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        ///     Gets the Current balance.
        /// </summary>
        public Money CurrentBalance { get; }

        /// <summary>
        ///     Gets the Transactions.
        /// </summary>
        public List<Transaction> Transactions { get; }
    }
}
