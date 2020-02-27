namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Account = InMemoryDataAccess.Account;
    using Credit = InMemoryDataAccess.Credit;

    public sealed class AccountRepository : IAccountRepository
    {
        private readonly MangaContext _context;

        public AccountRepository(MangaContext context)
        {
            this._context = context;
        }

        public async Task Add(IAccount account, ICredit credit)
        {
            this._context.Accounts.Add((Account)account);
            this._context.Credits.Add((Credit)credit);
            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task Delete(IAccount account)
        {
            var accountOld = this._context.Accounts
                .Where(e => e.Id.Equals(account.Id))
                .SingleOrDefault();

            this._context.Accounts.Remove(accountOld);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task<IAccount> GetAccount(AccountId accountId)
        {
            var account = this._context.Accounts
                .Where(e => e.Id.Equals(accountId))
                .SingleOrDefault();

            if (account is null)
            {
                throw new AccountNotFoundException($"The account {accountId} does not exist or is not processed yet.");
            }

            return await Task.FromResult<Domain.Accounts.Account>(account)
                .ConfigureAwait(false);
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            Domain.Accounts.Account accountOld = this._context.Accounts
                .Where(e => e.Id.Equals(account.Id))
                .SingleOrDefault();

            accountOld = (Domain.Accounts.Account)account;
            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            Domain.Accounts.Account accountOld = this._context.Accounts
                .Where(e => e.Id.Equals(account.Id))
                .SingleOrDefault();

            accountOld = (Domain.Accounts.Account)account;
            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
