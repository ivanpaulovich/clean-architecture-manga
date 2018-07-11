namespace Manga.Infrastructure.DapperDataAccess.Repositories
{
    using Dapper;
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly string connectionString;

        public CustomerReadOnlyRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task Add(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string insertCustomerSQL = "INSERT INTO Customer (Id, Name, SSN) VALUES (@Id, @Name, @SSN)";
                DynamicParameters customerParameters = new DynamicParameters();
                customerParameters.Add("@id", customer.Id);
                customerParameters.Add("@name", (string)customer.Name, DbType.AnsiString);
                customerParameters.Add("@SSN", (string)customer.SSN, DbType.AnsiString);

                int customerRows = await db.ExecuteAsync(insertCustomerSQL, customerParameters);
            }
        }

        public async Task<Customer> Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string customerSQL = "SELECT * FROM Customer WHERE Id = @Id";
                Entities.Customer customer = await db
                    .QueryFirstOrDefaultAsync<Entities.Customer>(customerSQL, new { id });
					
				if (customer == null)
                    return null;

                string accountSQL = "SELECT * FROM Account WHERE CustomerId = @Id";
                IEnumerable<Guid> accounts = await db
                    .QueryAsync<Guid>(accountSQL, new { id });

                AccountCollection accountCollection = new AccountCollection();

                foreach (Guid accountId in accounts)
                {
                    accountCollection.Add(accountId);
                }

                Customer result = Customer.Load(
                    customer.Id,
                    customer.Name,
                    customer.SSN,
                    accountCollection);

                return result;
            }
        }

        public async Task Update(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string updateCustomerSQL = "UPDATE Customer SET Name = @Name, SSN = @SSN WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(updateCustomerSQL, customer);
            }
        }
    }
}
