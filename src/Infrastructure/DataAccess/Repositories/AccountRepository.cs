// <copyright file="AccountRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Account = Entities.Account;
    using Credit = Entities.Credit;
    using Debit = Entities.Debit;

    public sealed class AccountRepository : IAccountRepository
    {
        private readonly MangaContext _context;

        public AccountRepository(MangaContext context)
        {
            this._context = context ??
                            throw new ArgumentNullException(nameof(context));
        }

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

        public async Task Add(IAccount account, ICredit credit)
        {
            await this._context
                .Accounts
                .AddAsync((Account)account)
                .ConfigureAwait(false);

            await this._context
                .Credits
                .AddAsync((Credit)credit)
                .ConfigureAwait(false);
        }

        public async Task Delete(IAccount account)
        {
            const string deleteSQL = @"DELETE FROM Credit WHERE AccountId = @Id;
                      DELETE FROM Debit WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

            var id = new SqlParameter("@Id", account.Id);

            await this._context
                .Database
                .ExecuteSqlRawAsync(
                    deleteSQL, id)
                .ConfigureAwait(false);
        }

        public async Task<IAccount> GetAccount(AccountId id)
        {
            var account = await this._context
                .Accounts
                .Where(a => a.Id.Equals(id))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (account is null)
            {
                return null;
            }

            var credits = this._context
                .Credits
                .Where(e => e.AccountId.Equals(id))
                .ToList();

            var debits = this._context
                .Debits
                .Where(e => e.AccountId.Equals(id))
                .ToList();

            account.Credits
                .AddRange(credits);
            account.Debits
                .AddRange(debits);

            return account;
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            await this._context
                .Credits
                .AddAsync((Credit)credit);
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            await this._context
                .Debits
                .AddAsync((Debit)debit);
        }
    }
}
