namespace Infrastructure.EntityFrameworkDataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
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

        public async Task Add(IAccount account, ICredit credit)
        {
            await this._context.Accounts.AddAsync((Account)account);
            await this._context.Credits.AddAsync((Credit)credit);
        }

        public async Task Delete(IAccount account)
        {
            string deleteSQL =
                @"DELETE FROM Credit WHERE AccountId = @Id;
                      DELETE FROM Debit WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

            var id = new SqlParameter("@Id", account.Id);

            int affectedRows = await this._context.Database.ExecuteSqlRawAsync(
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
                throw new AccountNotFoundException($"The account {id} does not exist or is not processed yet.");
            }

            var credits = this._context.Credits
                .Where(e => e.AccountId.Equals(id))
                .ToList();

            var debits = this._context.Debits
                .Where(e => e.AccountId.Equals(id))
                .ToList();

            account.Load(credits, debits);

            return account;
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            await this._context.Credits.AddAsync((Credit)credit);
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            await this._context.Debits.AddAsync((Debit)debit);
        }
    }
}
