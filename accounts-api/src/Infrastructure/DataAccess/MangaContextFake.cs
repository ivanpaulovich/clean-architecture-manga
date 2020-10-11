// <copyright file="MangaContextFake.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess
{
    using System;
    using System.Collections.ObjectModel;
    using Domain;
    using Domain.Credits;
    using Domain.Debits;
    using Domain.ValueObjects;

    /// <summary>
    /// </summary>
    public sealed class MangaContextFake
    {
        /// <summary>
        /// </summary>
        public MangaContextFake()
        {
            Credit credit = new Credit(
                new CreditId(Guid.NewGuid()),
                SeedData.DefaultAccountId,
                DateTime.Now,
                800,
                Currency.Dollar.Code);

            Debit debit = new Debit(
                new DebitId(Guid.NewGuid()),
                SeedData.DefaultAccountId,
                DateTime.Now,
                300,
                Currency.Dollar.Code);

            Account account = new Account(
                SeedData.DefaultAccountId,
                SeedData.DefaultExternalUserId,
                Currency.Dollar);

            account.CreditsCollection.Add(credit);
            account.DebitsCollection.Add(debit);

            this.Accounts.Add(account);
            this.Credits.Add(credit);
            this.Debits.Add(debit);

            Account account2 = new Account(
                SeedData.SecondAccountId,
                SeedData.SecondExternalUserId,
                Currency.Dollar);

            this.Accounts.Add(account2);
        }

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
