namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public sealed class AccountRepository : IAccountRepository
    {
        private readonly MangaContext _context;

        public AccountRepository(MangaContext context)
        {
            _context = context;
        }

        public async Task Add(IAccount account, ICredit credit)
        {
            _context.Accounts.Add((InMemoryDataAccess.Account)account);
            _context.Credits.Add((InMemoryDataAccess.Credit)credit);
            await Task.CompletedTask;
        }

        public async Task Delete(IAccount account)
        {
            var accountOld = _context.Accounts
                .Where(e => e.Id.Equals(account.Id))
                .SingleOrDefault();

            _context.Accounts.Remove(accountOld);

            await Task.CompletedTask;
        }

        public async Task<IAccount> Get(AccountId accountId)
        {
            var account = _context.Accounts
                .Where(e => e.Id.Equals(accountId))
                .SingleOrDefault();

            if (account is null)
            {
                throw new AccountNotFoundException($"The account {accountId} does not exist or is not processed yet.");
            }

            return await Task.FromResult<Account>(account);
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id.Equals(account.Id))
                .SingleOrDefault();

            accountOld = (Account)account;
            await Task.CompletedTask;
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id.Equals(account.Id))
                .SingleOrDefault();

            accountOld = (Account)account;
            await Task.CompletedTask;
        }
    }
}
