namespace Manga.Application.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using Manga.Application.Responses;
    using Manga.Domain.Customers;

    public class GetCustomerDetailsInteractor : IInputBoundary<GetCustomerDetaisCommand>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<CustomerResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public GetCustomerDetailsInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOutputBoundary<CustomerResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(GetCustomerDetaisCommand message)
        {
            Domain.Customers.Customer customer = await this.customerReadOnlyRepository.Get(message.CustomerId);
            CustomerResponse response = responseConverter.Map<CustomerResponse>(customer);

            outputBoundary.Populate(response);
        }
    }
}