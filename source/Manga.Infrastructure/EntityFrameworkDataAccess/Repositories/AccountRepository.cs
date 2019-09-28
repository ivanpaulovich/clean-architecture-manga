namespace Manga.Infrastructure.EntityFrameworkDataAccess
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    public sealed class AccountRepository : IAccountRepository
    {
        private readonly MangaContext _context;

        public AccountRepository(MangaContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(IAccount account, ICredit credit)
        {
            await _context.Accounts.AddAsync((Account) account);
            await _context.Credits.AddAsync((Credit) credit);
        }

        public async Task Delete(IAccount account)
        {
            string deleteSQL =
                @"DELETE FROM Credit WHERE AccountId = @Id;
                      DELETE FROM Debit WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

            var id = new SqlParameter("@Id", account.Id);

            int affectedRows = await _context.Database.ExecuteSqlRawAsync(
                deleteSQL, id);
        }

        public async Task<IAccount> TryGet(Guid id)
        {
            Account account = await _context
                .Accounts
                .Where(a => a.Id == id)
                .SingleOrDefaultAsync();

            if (account == null)
                throw new AccountNotFoundException($"Account {id} not found.");

            var credits = _context.Credits
                .Where(e => e.AccountId == id)
                .ToList();

            var debits = _context.Debits
                .Where(e => e.AccountId == id)
                .ToList();

            account.Load(credits, debits);

            return account;
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            await _context.Credits.AddAsync((Credit) credit);
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            await _context.Debits.AddAsync((Debit) debit);
        }
    }
}