namespace Acerola.Application.Accounts.Close
{
    using System;
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
            if (accountReadOnlyRepository == null)
                throw new ArgumentNullException(nameof(accountReadOnlyRepository));

            if (accountWriteOnlyRepository == null)
                throw new ArgumentNullException(nameof(accountWriteOnlyRepository));

            if (outputBoundary == null)
                throw new ArgumentNullException(nameof(outputBoundary));

            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
        }

        public async Task Handle(Request request)
        {
            Account account = accountReadOnlyRepository.Get(request.AccountId).Result;

            await accountWriteOnlyRepository.Delete(account);

            this.outputBoundary.Handle(new Response());
        }

        public IOutputBoundary Presenter
        {
            get
            {
                return outputBoundary;
            }
        }
    }
}
