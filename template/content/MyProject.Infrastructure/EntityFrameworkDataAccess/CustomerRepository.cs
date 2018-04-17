namespace MyProject.Infrastructure.EntityFrameworkDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Collections.Generic;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            int affectedRows = await _context.SaveChangesAsync();
        }

        public async Task<Customer> Get(Guid id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            IEnumerable<Guid> accounts = await _context
                .Accounts
                .Where(p => p.CustomerId == id)
                .Select(e => e.Id)
                .ToListAsync();

            Proxies.Customer customerProxy = new Proxies.Customer(customer, accounts);
            return customerProxy;
        }

        public async Task Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
