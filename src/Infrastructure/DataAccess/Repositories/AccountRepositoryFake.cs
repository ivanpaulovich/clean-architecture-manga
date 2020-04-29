// <copyright file="AccountRepositoryFake.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Account = Entities.Account;
    using Credit = Entities.Credit;

    /// <inheritdoc />
    public sealed class AccountRepositoryFake : IAccountRepository
    {
        private readonly MangaContextFake _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public AccountRepositoryFake(MangaContextFake context) => this._context = context;

        /// <inheritdoc />
        public async Task<IList<IAccount>> GetBy(CustomerId customerId)
        {
            var accounts = this._context
                .Accounts
                .Where(e => e.CustomerId.Equals(customerId))
                .Select(e => (IAccount)e)
                .ToList();

            return await Task.FromResult(accounts)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Add(IAccount account, ICredit credit)
        {
            this._context
                .Accounts
                .Add((Account)account);

            this._context
                .Credits
                .Add((Credit)credit);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Delete(IAccount account)
        {
            Account accountOld = this._context
                .Accounts
                .SingleOrDefault(e => e.Id.Equals(account.Id));

            this._context
                .Accounts
                .Remove(accountOld);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IAccount> GetAccount(AccountId accountId)
        {
            Account account = this._context
                .Accounts
                .SingleOrDefault(e => e.Id.Equals(accountId));

            if (account is null)
            {
                return null!;
            }

            return await Task.FromResult<Domain.Accounts.Account>(account)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Update(IAccount account, ICredit credit)
        {
            Domain.Accounts.Account accountOld = this._context
                .Accounts
                .SingleOrDefault(e => e.Id.Equals(account.Id));

            accountOld = (Domain.Accounts.Account)account;
            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task Update(IAccount account, IDebit debit)
        {
            Domain.Accounts.Account accountOld = this._context
                .Accounts
                .SingleOrDefault(e => e.Id.Equals(account.Id));

            accountOld = (Domain.Accounts.Account)account;
            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
