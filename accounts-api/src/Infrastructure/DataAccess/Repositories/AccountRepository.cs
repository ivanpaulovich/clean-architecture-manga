// <copyright file="AccountRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using Domain;
    using Domain.Credits;
    using Domain.Debits;
    using Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
                .AddAsync(account)
                .ConfigureAwait(false);

            await this._context
                .Credits
                .AddAsync(credit)
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
                this._context.Accounts.Remove(account);
            }
        }

        /// <inheritdoc />
        public async Task<IAccount> GetAccount(AccountId accountId)
        {
            Account account = await this._context
                .Accounts
                .Where(e => e.AccountId == accountId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (account is Account findAccount)
            {
                return await this.LoadTransactions(accountId, findAccount).ConfigureAwait(false);
            }

            return AccountNull.Instance;
        }

        /// <inheritdoc />
        public async Task Update(Account account, Credit credit) => await this._context
            .Credits
            .AddAsync(credit)
            .ConfigureAwait(false);

        /// <inheritdoc />
        public async Task Update(Account account, Debit debit) => await this._context
            .Debits
            .AddAsync(debit)
            .ConfigureAwait(false);

        public async Task<IAccount> Find(AccountId accountId, string externalUserId)
        {
            Account account = await this._context
                .Accounts
                .Where(e => e.ExternalUserId == externalUserId && e.AccountId == accountId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (account is Account findAccount)
            {
                return await this.LoadTransactions(accountId, findAccount).ConfigureAwait(false);
            }

            return AccountNull.Instance;
        }

        public async Task<IList<Account>> GetAccounts(string externalUserId)
        {
            var accounts = await this._context
                .Accounts
                .Where(e => e.ExternalUserId == externalUserId)
                .ToListAsync()
                .ConfigureAwait(false);

            return accounts;
        }

        private async Task<IAccount> LoadTransactions(AccountId accountId, Account findAccount)
        {
            List<Credit> credits = await this._context
                .Credits
                .Where(e => e.AccountId.Equals(accountId))
                .ToListAsync()
                .ConfigureAwait(false);

            List<Debit> debits = await this._context
                .Debits
                .Where(e => e.AccountId.Equals(accountId))
                .ToListAsync()
                .ConfigureAwait(false);

            findAccount.CreditsCollection
                .AddRange(credits);
            findAccount.DebitsCollection
                .AddRange(debits);

            return findAccount;
        }
    }
}
