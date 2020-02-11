// <copyright file="IAccountFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts
{
    using System;
    using Credits;
    using Customers.ValueObjects;
    using Debits;
    using ValueObjects;

    /// <summary>
    ///     Account
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity-factory">
    ///         Entity
    ///         Factory Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IAccountFactory
    {
        /// <summary>
        ///     Creates a new Account.
        /// </summary>
        /// <param name="customerId">CustomerId.</param>
        /// <returns>New Account instance.</returns>
        IAccount NewAccount(CustomerId customerId);

        /// <summary>
        ///     Creates a new Credit.
        /// </summary>
        /// <param name="account">Account object.</param>
        /// <param name="amountToDeposit">Amount to Deposit.</param>
        /// <param name="transactionDate">Transaction date.</param>
        /// <returns>New Credit instance.</returns>
        ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate);

        /// <summary>
        ///     Creates a new Debit.
        /// </summary>
        /// <param name="account">Account object.</param>
        /// <param name="amountToWithdraw">Amount to Withdraw.</param>
        /// <param name="transactionDate">Transaction date.</param>
        /// <returns>New Debit instance.</returns>
        IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate);
    }
}
