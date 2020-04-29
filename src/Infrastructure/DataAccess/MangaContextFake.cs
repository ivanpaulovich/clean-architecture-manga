// <copyright file="MangaContextFake.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using System;
    using System.Collections.ObjectModel;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Entities;
    using Credit = Entities.Credit;
    using Debit = Entities.Debit;

    /// <summary>
    /// </summary>
    public sealed class MangaContextFake
    {
        /// <summary>
        /// </summary>
        public MangaContextFake()
        {
            var customer = new Customer(
                DefaultCustomerId,
                new Name(Messages.UserName),
                new SSN(Messages.UserSSN));

            customer.Accounts
                .AddRange(new[] {DefaultAccountId});

            var user1 = new User(
                new ExternalUserId(Messages.ExternalUserID),
                customer.Name,
                customer.Id);

            var credit = new Credit(
                new CreditId(Guid.NewGuid()),
                DefaultAccountId,
                new PositiveMoney(800),
                DateTime.Now);

            var debit = new Debit(
                new DebitId(Guid.NewGuid()),
                DefaultAccountId,
                new PositiveMoney(300),
                DateTime.Now);

            var account = new Account(
                DefaultAccountId,
                DefaultCustomerId);

            account.Credits.Add(credit);
            account.Debits.Add(debit);

            this.Customers.Add(customer);
            this.Accounts.Add(account);
            this.Credits.Add(credit);
            this.Debits.Add(debit);
            this.Users.Add(user1);

            var secondCustomer = new Customer(
                SecondCustomerId,
                new Name(Messages.UserName1),
                new SSN(Messages.UserSSN1));

            secondCustomer.Accounts.Add(SecondAccountId);

            var secondUser = new User(
                new ExternalUserId(Messages.ExternalUserID1),
                secondCustomer.Name,
                secondCustomer.Id);

            var secondAccount = new Account(
                SecondAccountId,
                SecondCustomerId);

            this.Customers.Add(secondCustomer);
            this.Accounts.Add(secondAccount);
            this.Users.Add(secondUser);
        }

        /// <summary>
        ///     Gets or sets Users.
        /// </summary>
        public Collection<User> Users { get; } = new Collection<User>();

        /// <summary>
        ///     Gets or sets Customers.
        /// </summary>
        public Collection<Customer> Customers { get; } = new Collection<Customer>();

        /// <summary>
        ///     Gets or sets Accounts.
        /// </summary>
        public Collection<Account> Accounts { get; } = new Collection<Account>();

        /// <summary>
        ///     Gets or sets Credits.
        /// </summary>
        public Collection<Credit> Credits { get; } = new Collection<Credit>();

        /// <summary>
        ///     Gets or sets Debits.
        /// </summary>
        private Collection<Debit> Debits { get; } = new Collection<Debit>();

        /// <summary>
        ///     Gets or sets DefaultCustomerId.
        /// </summary>
        public static CustomerId DefaultCustomerId { get; } = new CustomerId(Guid.NewGuid());

        /// <summary>
        ///     Gets or sets DefaultAccountId.
        /// </summary>
        public static AccountId DefaultAccountId { get; } = new AccountId(Guid.NewGuid());

        private static CustomerId SecondCustomerId { get; } = new CustomerId(Guid.NewGuid());

        /// <summary>
        ///     Gets or sets SecondAccountId.
        /// </summary>
        public static AccountId SecondAccountId { get; } = new AccountId(Guid.NewGuid());
    }
}
