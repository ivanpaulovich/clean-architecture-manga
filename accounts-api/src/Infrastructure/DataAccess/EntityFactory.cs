// <copyright file="EntityFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using Domain;
    using Domain.Credits;
    using Domain.Debits;
    using Domain.ValueObjects;
    using System;

    /// <summary>
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity-factory">
    ///         Entity
    ///         Factory Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class EntityFactory : IAccountFactory
    {
        /// <inheritdoc />
        public Account NewAccount(string externalUserId, Currency currency)
            => new Account(new AccountId(Guid.NewGuid()), externalUserId, currency);

        /// <inheritdoc />
        public Credit NewCredit(
            Account account,
            PositiveMoney amountToDeposit,
            DateTime transactionDate) =>
            new Credit(new CreditId(Guid.NewGuid()), account.AccountId, transactionDate,
                amountToDeposit.Amount, amountToDeposit.Currency.Code);

        /// <inheritdoc />
        public Debit NewDebit(
            Account account,
            PositiveMoney amountToWithdraw,
            DateTime transactionDate) =>
            new Debit(new DebitId(Guid.NewGuid()), account.AccountId, transactionDate, amountToWithdraw.Amount,
                amountToWithdraw.Currency.Code);
    }
}
