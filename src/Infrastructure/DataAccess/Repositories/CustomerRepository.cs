// <copyright file="CustomerRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Customer = Entities.Customer;

    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly MangaContext _context;

        public CustomerRepository(MangaContext context) => this._context = context ??
                                                                           throw new ArgumentNullException(
                                                                               nameof(context));

        public async Task Add(ICustomer customer) =>
            await this._context
                .Customers
                .AddAsync((Customer)customer)
                .ConfigureAwait(false);

        public async Task<ICustomer> GetBy(CustomerId customerId)
        {
            Customer customer = await this._context
                .Customers
                .Where(c => c.Id.Equals(customerId))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (customer is null)
            {
                return null!;
            }

            var accounts = this._context
                .Accounts
                .Where(e => e.CustomerId.Equals(customer.Id))
                .Select(e => e.Id)
                .ToList();

            customer.Accounts
                .AddRange(accounts);

            return customer;
        }

        public async Task Update(ICustomer customer)
        {
            this._context
                .Customers
                .Update((Customer)customer);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
