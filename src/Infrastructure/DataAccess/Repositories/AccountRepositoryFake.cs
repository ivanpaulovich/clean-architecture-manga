// <copyright file="AccountRepositoryFake.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

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
                .Add((Entities.Account)account);

            this._context
                .Credits
                .Add((Entities.Credit)credit);

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
                .Remove((Entities.Account)accountOld);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task<IAccount> Find(AccountId accountId, CustomerId customerId)
        {
            IAccount account = this._context
                .Accounts
                .Where(e => e.CustomerId == customerId && e.AccountId.Equals(accountId))
                .Select(e => (IAccount)e)
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
        public async Task Update(Account account, Credit credit)
        {
            Account accountOld = this._context
                .Accounts
                .SingleOrDefault(e => e.AccountId.Equals(account.AccountId));

            if (accountOld != null)
            {
                this._context.Accounts.Remove((Entities.Account)accountOld);
            }

            this._context.Accounts.Add((Entities.Account)account);
            this._context.Credits.Add((Entities.Credit)credit);

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
                this._context.Accounts.Remove((Entities.Account)accountOld);
                this._context.Accounts.Add((Entities.Account)account);
            }

            this._context.Debits.Add((Entities.Debit)debit);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
