// <copyright file="RegisterOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Register
{
    using System;
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Customers;
    using Domain.Security.ValueObjects;

    /// <summary>
    ///     Register Output Message.
    /// </summary>
    public sealed class RegisterOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterOutput" /> class.
        /// </summary>
        /// <param name="externalUserId">External User Id.</param>
        /// <param name="customer">Customer object.</param>
        /// <param name="account">Account object.</param>
        public RegisterOutput(ExternalUserId externalUserId, ICustomer customer, IAccount account)
        {
            if (account is Domain.Accounts.Account accountEntity)
            {
                List<Transaction> transactionResults = new List<Transaction>();
                foreach (ICredit credit in accountEntity.Credits
                    .GetTransactions())
                {
                    Credit creditEntity = (Credit)credit;

                    Transaction transactionOutput = new Transaction(
                        Credit.Description,
                        creditEntity.Amount,
                        creditEntity.TransactionDate);

                    transactionResults.Add(transactionOutput);
                }

                foreach (IDebit debit in accountEntity.Debits
                    .GetTransactions())
                {
                    Debit debitEntity = (Debit)debit;

                    Transaction transactionOutput = new Transaction(
                        Debit.Description,
                        debitEntity.Amount,
                        debitEntity.TransactionDate);

                    transactionResults.Add(transactionOutput);
                }

                this.Account = new Account(
                    accountEntity.Id,
                    accountEntity.GetCurrentBalance(),
                    transactionResults);

                List<Account> accountOutputs = new List<Account>();
                accountOutputs.Add(this.Account);

                this.Customer = new Customer(externalUserId, customer, accountOutputs);
            }
            else
                throw new ArgumentNullException(nameof(account));
        }

        /// <summary>
        ///     Gets the Customer.
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        ///     Gets the Account.
        /// </summary>
        public Account Account { get; }
    }
}
