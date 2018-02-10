namespace Acerola.Application.UseCases.ListAllAccounts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Acerola.Domain.Accounts;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;

        public Interactor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IOutputBoundary<Response> outputBoundary)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
        }

        public async Task Handle(Request message)
        {
            IEnumerable<Account> data = await this.accountReadOnlyRepository.ListAll();

            IList<Account> accounts = new List<Account>();

            Response response = new Response();

            outputBoundary.Populate(response);
        }
    }
}
