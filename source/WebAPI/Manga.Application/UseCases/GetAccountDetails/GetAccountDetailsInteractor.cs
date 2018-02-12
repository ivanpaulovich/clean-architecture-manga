namespace Manga.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using Manga.Application.Responses;
    using Manga.Domain.Customers;

    public class GetAccountDetailsInteractor : IInputBoundary<GetAccountDetailsCommand>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<AccountResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public GetAccountDetailsInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOutputBoundary<AccountResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(GetAccountDetailsCommand message)
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
