namespace Acerola.Application.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using Acerola.Domain.Customers;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;

        public Interactor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOutputBoundary<Response> outputBoundary)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
        }

        public async Task Handle(Request message)
        {
            Customer customer = await this.customerReadOnlyRepository.Get(message.CustomerId);

            Response response = new Response(
                customer.Id,
                customer.PIN.Text,
                customer.Name.Text);

            outputBoundary.Populate(response);
        }
    }
}