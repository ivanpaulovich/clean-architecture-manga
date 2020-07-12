// <copyright file="CustomerRepositoryFake.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Domain.Customers;

    public sealed class CustomerRepositoryFake : ICustomerRepository
    {
        private readonly MangaContextFake _context;

        public CustomerRepositoryFake(MangaContextFake context) => this._context = context;

        public async Task<ICustomer> Find(UserId userId)
        {
            Customer customer = this._context
                .Customers
                .SingleOrDefault(e => e.UserId.Equals(userId));

            if (customer == null)
            {
                return CustomerNull.Instance;
            }

            var accounts = this._context
                .Accounts
                .Where(e => e.CustomerId == customer.CustomerId)
                .Select(e => e.AccountId)
                .ToList();

            customer.Accounts
                .AddRange(accounts);

            return await Task.FromResult(customer)
                .ConfigureAwait(false);
        }

        public async Task Add(Customer customer)
        {
            this._context
                .Customers
                .Add((Entities.Customer)customer);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task Update(Customer customer)
        {
            Customer customerOld = this._context
                .Customers
                .SingleOrDefault(e => e.CustomerId.Equals(customer.CustomerId));

            if (customerOld != null)
            {
                this._context.Customers.Remove((Entities.Customer)customerOld);
                this._context.Customers.Add((Entities.Customer)customer);
            }

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
