namespace Manga.Infrastructure.InMemoryDataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(Account account, Credit credit)
        {
            _context.Accounts.Add(account);
            await Task.CompletedTask;
        }

        public async Task Delete(Account account)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            _context.Accounts.Remove(accountOld);

            await Task.CompletedTask;
        }

        public async Task<Account> Get(Guid id)
        {
            Account account = _context.Accounts
                .Where(e => e.Id == id)
                .SingleOrDefault();

            return await Task.FromResult<Account>(account);
        }

        public async Task Update(Account account, Credit credit)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            accountOld = account;
            await Task.CompletedTask;
        }

        public async Task Update(Account account, Debit debit)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            accountOld = account;
            await Task.CompletedTask;
        }
    }
}
