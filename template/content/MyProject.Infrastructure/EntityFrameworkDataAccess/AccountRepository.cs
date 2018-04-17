namespace MyProject.Infrastructure.EntityFrameworkDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly Context context;

        public AccountRepository(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Account account, Credit credit)
        {
            context.Entry(credit).State = EntityState.Added;
            await context.Accounts.AddAsync(account);
            int affectedRows = await context.SaveChangesAsync();
        }

        public async Task Delete(Account account)
        {
            string deleteSQL =
                    @"DELETE FROM [Transaction] WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";

            var id = new SqlParameter("@Id", account.Id);

            int affectedRows = await context.Database.ExecuteSqlCommandAsync(
                deleteSQL, id);
        }

        public async Task<Account> Get(Guid id)
        {
            var account = await context.Accounts.FindAsync(id);

            if (account == null)
                return null;

            await context.Entry(account)
                .Collection(i => i.Transactions)
                .LoadAsync();

            return account;
        }

        public async Task Update(Account account, Transaction transaction)
        {
            context.Entry(transaction).State = EntityState.Added;

            int affectedRows = await context.SaveChangesAsync();
        }
    }
}
