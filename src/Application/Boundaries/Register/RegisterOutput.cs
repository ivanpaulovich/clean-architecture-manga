// <copyright file="RegisterOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Register
{
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Customers;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// Register Output Message.
    /// </summary>
    public sealed class RegisterOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterOutput"/> class.
        /// </summary>
        /// <param name="externalUserId">External User Id.</param>
        /// <param name="customer">Customer object.</param>
        /// <param name="account">Account object.</param>
        public RegisterOutput(ExternalUserId externalUserId, ICustomer customer, IAccount account)
        {
            var accountEntity = (Domain.Accounts.Account)account;

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (ICredit credit in accountEntity.Credits
                .GetTransactions())
            {
                Credit creditEntity = (Credit)credit;

                Transaction transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity.Amount,
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (IDebit debit in accountEntity.Debits
                .GetTransactions())
            {
                Debit debitEntity = (Debit)debit;

                Transaction transactionOutput = new Transaction(
                    debitEntity.Description,
                    debitEntity.Amount,
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            this.Account = new Account(
                account.Id,
                account.GetCurrentBalance(),
                transactionResults);

            List<Account> accountOutputs = new List<Account>();
            accountOutputs.Add(this.Account);

            this.Customer = new Customer(externalUserId, customer, accountOutputs);
        }

        /// <summary>
        /// Gets the Customer.
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        /// Gets the Account.
        /// </summary>
        public Account Account { get; }
    }
}
