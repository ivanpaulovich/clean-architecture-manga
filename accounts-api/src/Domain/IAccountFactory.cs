// <copyright file="IAccountFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain;

using System;
using Credits;
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
    /// <param name="externalUserId">ExternalUserId.</param>
    /// <param name="currency">Currency</param>
    /// <returns>New Account instance.</returns>
    Account NewAccount(string externalUserId, Currency currency);

    /// <summary>
    ///     Creates a new Credit.
    /// </summary>
    /// <param name="account">Account object.</param>
    /// <param name="amountToDeposit">Amount to Deposit.</param>
    /// <param name="transactionDate">Transaction date.</param>
    /// <returns>New Credit instance.</returns>
    Credit NewCredit(Account account, Money amountToDeposit, DateTime transactionDate);

    /// <summary>
    ///     Creates a new Debit.
    /// </summary>
    /// <param name="account">Account object.</param>
    /// <param name="amountToWithdraw">Amount to Withdraw.</param>
    /// <param name="transactionDate">Transaction date.</param>
    /// <returns>New Debit instance.</returns>
    Debit NewDebit(Account account, Money amountToWithdraw, DateTime transactionDate);
}
