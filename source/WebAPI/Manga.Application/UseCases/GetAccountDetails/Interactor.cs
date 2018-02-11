namespace Manga.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using Manga.Application.Responses;
    using Manga.Domain.Customers;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<AccountResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public Interactor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOutputBoundary<AccountResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request message)
        {
            var customer = await customerReadOnlyRepository.GetByAccount(message.AccountId);
            if (customer == null)
            {
                outputBoundary.Populate(null);
                return;
            }

            var account = customer.FindAccount(message.AccountId);
            AccountResponse response = responseConverter.Map<AccountResponse>(account);
            outputBoundary.Populate(response);
        }
    }
}
