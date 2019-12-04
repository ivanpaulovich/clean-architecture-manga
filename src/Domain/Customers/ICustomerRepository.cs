namespace Domain.Customers
{
    using System.Threading.Tasks;
    using Domain.Customers.ValueObjects;

    public interface ICustomerRepository
    {
        Task<ICustomer> GetBy(CustomerId customerId);

        Task Add(ICustomer customer);

        Task Update(ICustomer customer);
    }
}
