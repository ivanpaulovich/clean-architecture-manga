namespace Acerola.Application.Accounts.Close
{
    using System.Threading.Tasks;
    using Acerola.Domain.Accounts;

    public class Interactor : IInputBoundary
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary outputBoundary;

        public Interactor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary outputBoundary)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
        }

        public async Task Handle(RequestModel request)
        {
            Account account = accountReadOnlyRepository.Get(request.AccountId).Result;

            await accountWriteOnlyRepository.Delete(account);

            this.outputBoundary.Populate(new ResponseModel());
        }
    }
}
