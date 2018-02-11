namespace Manga.Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;
    using Manga.Domain.Accounts;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public Interactor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request request)
        {
            Account account = accountReadOnlyRepository.Get(request.AccountId).Result;
            await accountWriteOnlyRepository.Delete(account);

            Response response = responseConverter.Map<Response>(account);
            this.outputBoundary.Populate(response);
        }
    }
}