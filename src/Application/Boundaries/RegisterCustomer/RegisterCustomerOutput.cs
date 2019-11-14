namespace Application.Boundaries.RegisterCustomer
{
    using Domain.Customers;

    public sealed class RegisterCustomerOutput : IUseCaseOutput
    {
        public Customer Customer { get; }

        public RegisterCustomerOutput(ICustomer customer)
        {
            Customer = new Customer(customer);
        }
    }
}
