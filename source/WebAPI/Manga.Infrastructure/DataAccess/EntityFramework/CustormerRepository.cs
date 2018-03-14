namespace Manga.Infrastructure.DataAccess.EntityFramework
{
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;


    public class CustormerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly AccountBalanceContext _context;

        public CustormerRepository(AccountBalanceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Get(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            //if (customer != null)
            //{
            //    await _context.Entry(customer)
            //        .Collection(i => i.Accounts)
            //        .LoadAsync();
            //}

            return customer;
        }

        public async Task Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}