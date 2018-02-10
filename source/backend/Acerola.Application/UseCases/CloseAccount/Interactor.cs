namespace Acerola.Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;
    using Acerola.Domain.Accounts;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;

        public Interactor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
        }

        public async Task Handle(Request request)
        {
            Account account = accountReadOnlyRepository.Get(request.AccountId).Result;

            await accountWriteOnlyRepository.Delete(account);

            this.outputBoundary.Populate(new Response());
        }
    }
}
