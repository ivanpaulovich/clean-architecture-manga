namespace Acerola.Application.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using Acerola.Application.Responses;
    using Acerola.Domain.Customers;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<CustomerResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public Interactor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOutputBoundary<CustomerResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request message)
        {
            Domain.Customers.Customer customer = await this.customerReadOnlyRepository.Get(message.CustomerId);
            CustomerResponse response = responseConverter.Map<CustomerResponse>(customer);

            outputBoundary.Populate(response);
        }
    }
}