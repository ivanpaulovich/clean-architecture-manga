namespace Manga.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using Manga.Domain.Accounts;
    using Manga.Application.Responses;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<AccountResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public Interactor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IOutputBoundary<AccountResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request message)
        {
            var account = await accountReadOnlyRepository.Get(message.AccountId);
            AccountResponse response = responseConverter.Map<AccountResponse>(account);
            outputBoundary.Populate(response);
        }
    }
}
