// <copyright file="EntityFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Account = Entities.Account;
    using Credit = Entities.Credit;
    using Customer = Entities.Customer;
    using Debit = Entities.Debit;
    using User = Entities.User;

    /// <summary>
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity-factory">
    ///         Entity
    ///         Factory Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class EntityFactory : IUserFactory, ICustomerFactory, IAccountFactory
    {
        public IAccount NewAccount(CustomerId customerId)
            => new Account(new AccountId(Guid.NewGuid()), customerId);

        public ICredit NewCredit(
            IAccount account,
            PositiveMoney amountToDeposit,
            DateTime transactionDate)
            => new Credit(new CreditId(Guid.NewGuid()), account.Id, amountToDeposit, transactionDate);

        public IDebit NewDebit(
            IAccount account,
            PositiveMoney amountToWithdraw,
            DateTime transactionDate)
            => new Debit(new DebitId(Guid.NewGuid()), account.Id, amountToWithdraw, transactionDate);

        public ICustomer NewCustomer(SSN ssn, Name name)
            => new Customer(new CustomerId(Guid.NewGuid()), name, ssn);

        public IUser NewUser(CustomerId? customerId, ExternalUserId externalUserId, Name? name)
            => new User(externalUserId, name, customerId);
    }
}
