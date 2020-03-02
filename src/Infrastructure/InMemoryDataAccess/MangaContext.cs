// <copyright file="MangaContext.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.ObjectModel;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public sealed class MangaContext
    {
        public MangaContext()
        {
            this.Customers = new Collection<Customer>();
            this.Accounts = new Collection<Account>();
            this.Credits = new Collection<Credit>();
            this.Debits = new Collection<Debit>();
            this.Users = new Collection<User>();

            var customer = new Customer(
                DefaultCustomerId,
                new SSN("8608179999"),
                new Name("Ivan Paulovich"),
                new AccountId[] { DefaultAccountId });

            var user1 = new User(
                customer.Id,
                new ExternalUserId("github/ivanpaulovich"));

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
                DefaultCustomerId,
                new [] { credit },
                new [] { debit } );

            this.Customers.Add(customer);
            this.Accounts.Add(account);
            this.Credits.Add(credit);
            this.Debits.Add(debit);
            this.Users.Add(user1);

            var secondCustomer = new Customer(
                SecondCustomerId,
                new SSN("8408319999"),
                new Name("Andre Paulovich"),
                new [] { SecondAccountId });

            var secondUser = new User(
                secondCustomer.Id,
                new ExternalUserId("github/andrepaulovich"));

            var secondAccount = new Account(
                SecondAccountId,
                SecondCustomerId,
                Array.Empty<Credit>(),
                Array.Empty<Debit>());

            this.Customers.Add(secondCustomer);
            this.Accounts.Add(secondAccount);
            this.Users.Add(secondUser);
        }

        public Collection<User> Users { get; }

        public Collection<Customer> Customers { get; }

        public Collection<Account> Accounts { get; }

        public Collection<Credit> Credits { get; }

        public Collection<Debit> Debits { get; }

        public static CustomerId DefaultCustomerId { get; } = new CustomerId(Guid.NewGuid());

        public static AccountId DefaultAccountId { get; } = new AccountId(Guid.NewGuid());

        public static CustomerId SecondCustomerId { get; } = new CustomerId(Guid.NewGuid());

        public static AccountId SecondAccountId { get; } = new AccountId(Guid.NewGuid());
    }
}
