namespace Manga.Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public Interactor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request request)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(request.AccountId);
            customer.RemoveAccount(request.AccountId);
            await customerWriteOnlyRepository.Update(customer);

            Response response = responseConverter.Map<Response>(customer);
            this.outputBoundary.Populate(response);
        }
    }
}