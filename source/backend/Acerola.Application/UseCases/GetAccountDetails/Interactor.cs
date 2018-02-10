namespace Acerola.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using Acerola.Domain.Accounts;
    using System.Collections.Generic;

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
            Account account = await this.accountReadOnlyRepository.Get(message.AccountId);

            Response response = new Response(
                account.Id,
                account.CustomerId,
                account.CurrentBalance.Value,
                new List<Transaction>());

            outputBoundary.Populate(response);
        }
    }
}
