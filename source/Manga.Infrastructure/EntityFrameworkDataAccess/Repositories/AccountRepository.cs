namespace Manga.Infrastructure.EntityFrameworkDataAccess
{
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

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
            await _context.SaveChangesAsync();
        }

        public async Task Delete(IAccount account)
        {
            string deleteSQL =
                @"DELETE FROM Credit WHERE AccountId = @Id;
                      DELETE FROM Debit WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

            var id = new SqlParameter("@Id", account.Id);

            int affectedRows = await _context.Database.ExecuteSqlCommandAsync(
                deleteSQL, id);
        }

        public async Task<IAccount> Get(Guid id)
        {
            Account account = await _context
                .Accounts
                .FindAsync(id);

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
            await _context.SaveChangesAsync();
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            await _context.Debits.AddAsync((Debit) debit);
            await _context.SaveChangesAsync();
        }
    }
}