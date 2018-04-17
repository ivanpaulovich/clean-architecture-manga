namespace MyProject.Infrastructure.DapperDataAccess
{
    using Dapper;
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers;
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
                string insertCustomerSQL = "INSERT INTO Customer (Id, Name, PIN, Version) VALUES (@Id, @Name, @PIN, @Version)";
                DynamicParameters customerParameters = new DynamicParameters();
                customerParameters.Add("@id", customer.Id);
                customerParameters.Add("@name", customer.Name.Text, DbType.AnsiString);
                customerParameters.Add("@pin", customer.PIN.Text, DbType.AnsiString);
                customerParameters.Add("@version", customer.Version);

                int customerRows = await db.ExecuteAsync(insertCustomerSQL, customerParameters);
            }
        }

        public async Task<Customer> Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string customerSQL = "SELECT * FROM Customer WHERE Id = @Id";
                Proxies.Customer customer = await db
                    .QueryFirstOrDefaultAsync<Proxies.Customer>(customerSQL, new { id });
					
				if (customer == null)
                    return null;

                string accountSQL = "SELECT * FROM Account WHERE CustomerId = @Id";
                IEnumerable<Guid> accounts = await db
                    .QueryAsync<Guid>(accountSQL, new { id });

                customer.SetAccounts(accounts);
                return customer;
            }
        }

        public async Task Update(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string updateCustomerSQL = "UPDATE Customer SET Name = @Name, PIN = @PIN, Version = @Version WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(updateCustomerSQL, customer);
            }
        }
    }
}
