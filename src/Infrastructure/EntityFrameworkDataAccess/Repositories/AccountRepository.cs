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
            await _context.Accounts.AddAsync((EntityFrameworkDataAccess.Account)account);
            await _context.Credits.AddAsync((EntityFrameworkDataAccess.Credit)credit);
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

        public async Task<IAccount> Get(AccountId id)
        {
            var account = await _context
                .Accounts
                .Where(a => a.Id.Equals(id))
                .SingleOrDefaultAsync();

            if (account is null)
            {
                throw new AccountNotFoundException($"The account {id} does not exist or is not processed yet.");
            }

            var credits = _context.Credits
                .Where(e => e.AccountId.Equals(id))
                .ToList();

            var debits = _context.Debits
                .Where(e => e.AccountId.Equals(id))
                .ToList();

            account.Load(credits, debits);

            return account;
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            await _context.Credits.AddAsync((EntityFrameworkDataAccess.Credit)credit);
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            await _context.Debits.AddAsync((EntityFrameworkDataAccess.Debit)debit);
        }
    }
}
