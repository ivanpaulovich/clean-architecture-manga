// <copyright file="AccountRepositoryFake.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;
    using Domain.Credits;
    using Domain.Debits;
    using Domain.ValueObjects;

    /// <inheritdoc />
    public sealed class AccountRepositoryFake : IAccountRepository
    {
        private readonly MangaContextFake _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public AccountRepositoryFake(MangaContextFake context) => this._context = context;

        /// <inheritdoc />
        public async Task Add(Account account, Credit credit)
        {
            this._context
                .Accounts
                .Add(account);

            this._context
                .Credits
                .Add(credit);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Delete(AccountId accountId)
        {
            Account accountOld = this._context
                .Accounts
                .SingleOrDefault(e => e.AccountId.Equals(accountId));

            this._context
                .Accounts
                .Remove(accountOld);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task<IAccount> Find(AccountId accountId, string externalUserId)
        {
            Account account = this._context
                .Accounts
                .Where(e => e.ExternalUserId == externalUserId && e.AccountId.Equals(accountId))
                .Select(e => e)
                .SingleOrDefault();

            if (account == null)
            {
                return AccountNull.Instance;
            }

            return await Task.FromResult(account)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IAccount> GetAccount(AccountId accountId)
        {
            Account account = this._context
                .Accounts
                .SingleOrDefault(e => e.AccountId.Equals(accountId));

            if (account == null)
            {
                return AccountNull.Instance;
            }

            return await Task.FromResult(account)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IList<Account>> GetAccounts(string externalUserId)
        {
            List<Account> accounts = this._context
                .Accounts
                .Where(e => e.ExternalUserId == externalUserId)
                .ToList();

            return await Task.FromResult(accounts)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Update(Account account, Credit credit)
        {
            Account accountOld = this._context
                .Accounts
                .SingleOrDefault(e => e.AccountId.Equals(account.AccountId));

            if (accountOld != null)
            {
                this._context.Accounts.Remove(accountOld);
            }

            this._context.Accounts.Add(account);
            this._context.Credits.Add(credit);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Update(Account account, Debit debit)
        {
            Account accountOld = this._context
                .Accounts
                .SingleOrDefault(e => e.AccountId.Equals(account.AccountId));

            if (accountOld != null)
            {
                this._context.Accounts.Remove(accountOld);
                this._context.Accounts.Add(account);
            }

            this._context.Debits.Add(debit);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
