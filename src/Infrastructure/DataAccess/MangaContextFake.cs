// <copyright file="MangaContextFake.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using System;
    using System.Collections.ObjectModel;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Entities;

    /// <summary>
    /// </summary>
    public sealed class MangaContextFake
    {
        /// <summary>
        /// </summary>
        public MangaContextFake()
        {
            var user1 = new User(
                SeedData.DefaultUserId,
                SeedData.DefaultExternalUserId);

            var customer = new Customer(
                SeedData.DefaultCustomerId,
                new Name(Messages.UserName),
                new Name(Messages.UserName),
                new SSN(Messages.UserSSN),
                user1.UserId);

            var credit = new Credit(
                new CreditId(Guid.NewGuid()),
                SeedData.DefaultAccountId,
                DateTime.Now,
                800,
                Currency.Dollar.Code);

            var debit = new Debit(
                new DebitId(Guid.NewGuid()),
                SeedData.DefaultAccountId,
                DateTime.Now,
                300,
                Currency.Dollar.Code);

            var account = new Account(
                SeedData.DefaultAccountId,
                SeedData.DefaultCustomerId,
                Currency.Dollar);

            account.Credits.Add(credit);
            account.Debits.Add(debit);

            this.Users.Add(user1);
            this.Customers.Add(customer);
            this.Accounts.Add(account);
            this.Credits.Add(credit);
            this.Debits.Add(debit);

            var user2 = new User(
                SeedData.SecondUserId,
                SeedData.SecondExternalUserId);

            var customer2 = new Customer(
                SeedData.SecondCustomerId,
                new Name(Messages.UserName),
                new Name(Messages.UserName),
                new SSN(Messages.UserSSN),
                SeedData.SecondUserId);

            var account2 = new Account(
                SeedData.SecondAccountId,
                SeedData.SecondCustomerId,
                Currency.Dollar);

            this.Users.Add(user2);
            this.Customers.Add(customer2);
            this.Accounts.Add(account2);
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
        public Collection<Debit> Debits { get; } = new Collection<Debit>();
    }
}
