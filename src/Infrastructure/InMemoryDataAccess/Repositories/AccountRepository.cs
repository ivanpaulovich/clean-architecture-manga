namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Application.Repositories;
    using Domain.Accounts;

    public sealed class AccountRepository : IAccountRepository
    {
        private readonly MangaContext _context;

        public AccountRepository(MangaContext context)
        {
            _context = context;
        }

        public async Task Add(IAccount account, ICredit credit)
        {
            _context.Accounts.Add((InMemoryDataAccess.Account) account);
            _context.Credits.Add((InMemoryDataAccess.Credit) credit);
            await Task.CompletedTask;
        }

        public async Task Delete(IAccount account)
        {
            var accountOld = _context.Accounts
                .SingleOrDefault(e => e.Id == account.Id);

            _context.Accounts.Remove(accountOld);

            await Task.CompletedTask;
        }

        public async Task<IAccount> Get(Guid id)
        {
            Account account = _context.Accounts
                .SingleOrDefault(e => e.Id == id);

            if (account is null)
                throw new AccountNotFoundException($"The account {id} does not exist or is not processed yet.");

            return await Task.FromResult(account);
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            Account accountOld = _context.Accounts
                .SingleOrDefault(e => e.Id == account.Id);

            accountOld = (Account) account;
            await Task.CompletedTask;
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            Account accountOld = _context.Accounts
                .SingleOrDefault(e => e.Id == account.Id);

            accountOld = (Account) account;
            await Task.CompletedTask;
        }
    }
}
