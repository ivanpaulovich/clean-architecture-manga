namespace UnitTests.Presenters
{
    using Application.UseCases.GetCustomer;
    using Domain.Customers;

    public sealed class GetCustomerPresenterFake : IOutputPort
    {
        public Customer? Customer { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Customer customer) => this.Customer = customer;
    }
}
