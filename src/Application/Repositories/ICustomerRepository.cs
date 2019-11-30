namespace Application.Repositories
{
    using System.Threading.Tasks;
    using Domain.Customers;

    public interface ICustomerRepository
    {
        Task<ICustomer> GetBy(CustomerId customerId);

        Task Add(ICustomer customer);

        Task Update(ICustomer customer);
    }
}
