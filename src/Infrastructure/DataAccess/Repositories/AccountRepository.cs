// <copyright file="AccountRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public sealed class AccountRepository : IAccountRepository
    {
        private readonly MangaContext _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public AccountRepository(MangaContext context) => this._context = context ??
                                                                          throw new ArgumentNullException(
                                                                              nameof(context));

        /// <inheritdoc />
        public async Task Add(Account account, Credit credit)
        {
            await this._context
                .Accounts
                .AddAsync((Entities.Account)account)
                .ConfigureAwait(false);

            await this._context
                .Credits
                .AddAsync((Entities.Credit)credit)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Delete(AccountId accountId)
        {
            Account account = await this._context
                .Accounts
                .FindAsync(accountId)
                .ConfigureAwait(false);

            if (account != null)
            {
                this._context.Accounts.Remove((Entities.Account)account);
            }
        }

        /// <inheritdoc />
        public async Task<IAccount> GetAccount(AccountId accountId)
        {
            Entities.Account account = await this._context
                .Accounts
                .Where(e => e.AccountId == accountId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (account is Account findAccount)
            {
                List<Entities.Credit> credits = await this._context
                    .Credits
                    .Where(e => e.AccountId.Equals(accountId))
                    .ToListAsync()
                    .ConfigureAwait(false);

                List<Entities.Debit> debits = await this._context
                    .Debits
                    .Where(e => e.AccountId.Equals(accountId))
                    .ToListAsync()
                    .ConfigureAwait(false);

                findAccount.Credits
                    .AddRange(credits);
                findAccount.Debits
                    .AddRange(debits);

                return findAccount;
            }

            return AccountNull.Instance;
        }

        /// <inheritdoc />
        public async Task Update(Account account, Credit credit) => await this._context
            .Credits
            .AddAsync((Entities.Credit)credit)
            .ConfigureAwait(false);

        /// <inheritdoc />
        public async Task Update(Account account, Debit debit) => await this._context
            .Debits
            .AddAsync((Entities.Debit)debit)
            .ConfigureAwait(false);

        public async Task<IAccount> Find(AccountId accountId, CustomerId customerId)
        {
            Entities.Account account = await this._context
                .Accounts
                .Where(e => e.CustomerId == customerId && e.AccountId == accountId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (account is Account findAccount)
            {
                List<Entities.Credit> credits = await this._context
                    .Credits
                    .Where(e => e.AccountId.Equals(accountId))
                    .ToListAsync()
                    .ConfigureAwait(false);

                List<Entities.Debit> debits = await this._context
                    .Debits
                    .Where(e => e.AccountId.Equals(accountId))
                    .ToListAsync()
                    .ConfigureAwait(false);

                findAccount.Credits
                    .AddRange(credits);
                findAccount.Debits
                    .AddRange(debits);

                return findAccount;
            }

            return AccountNull.Instance;
        }
    }
}
