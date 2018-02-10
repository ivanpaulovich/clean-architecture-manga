namespace Acerola.Application.UseCases.ListAllCustomers
{
    using System.Threading.Tasks;
    using Acerola.Domain.Customers;
    using System.Collections.Generic;

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
            var customers1 = await this.customerReadOnlyRepository.GetAll();

            List<CustomerResponse> customers = new List<CustomerResponse>();

            Response response = new Response(customers);

            outputBoundary.Populate(response);
        }
    }
}
