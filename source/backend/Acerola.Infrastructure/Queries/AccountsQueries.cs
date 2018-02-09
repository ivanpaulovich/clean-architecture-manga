namespace Acerola.Infrastructure.Queries
{
    using Acerola.Application.Queries;
    using Acerola.Application.DTO;
    using Acerola.Domain.Accounts;
    using Acerola.Infrastructure.DataAccess;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Acerola.Application.Mappers;
    using Acerola.Application.Accounts.Details;

    public class AccountsQueries : IAccountsQueries
    {
        private readonly AccountBalanceContext mongoDB;
        private readonly IDTOMapper mapper;

        public AccountsQueries(AccountBalanceContext mongoDB, IDTOMapper mapper)
        {
            this.mongoDB = mongoDB;
            this.mapper = mapper;
        }

        public async Task<AccountData> GetAccount(Guid id)
        {
            Account data = await this.mongoDB.Accounts
                .Find(Builders<Account>.Filter.Eq("_id", id))
                .SingleOrDefaultAsync();

            if (data == null)
                throw new AccountNotFoundException($"The account {id} does not exists or is not processed yet.");

            AccountData accountVM = this.mapper.Map<AccountData>(data);

            return accountVM;
        }

        public async Task<IEnumerable<AccountData>> GetAll()
        {
            IEnumerable<Account> data = await this.mongoDB.Accounts
                .Find(e => true)
                .ToListAsync();

            List<AccountData> result = this.mapper.Map<List<AccountData>>(data);

            return result;
        }

        public async Task<IEnumerable<AccountData>> Get(Guid customerId)
        {
            IEnumerable<Account> data = await this.mongoDB.Accounts
                .Find(Builders<Account>
                .Filter.Eq("CustomerId", customerId))
                .ToListAsync();

            List<AccountData> result = this.mapper.Map<List<AccountData>>(data);

            return result;
        }
    }
}
