namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.OnBoardCustomer;
    using Domain.Customers;

    /// <summary>
    /// </summary>
    public sealed class OnBoardCustomerPresenterFake : IOutputPort
    {
        public Customer? Customer { get; private set; }
        public bool InvalidOutput { get; private set; }
        public void Invalid(Notification notification) => this.InvalidOutput = true;
        public void Ok(Customer customer) => this.Customer = customer;
    }
}
