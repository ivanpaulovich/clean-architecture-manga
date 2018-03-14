namespace Manga.Infrastructure.DataAccess.EntityFramework
{
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Manga.Domain.Accounts;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly AccountBalanceContext _context;

        public AccountRepository(AccountBalanceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Account account)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> Get(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account != null)
            {
                await _context.Entry(account)
                    .Collection(i => i.Transactions)
                    .LoadAsync();
            }

            return account;
        }

        public async Task Update(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}