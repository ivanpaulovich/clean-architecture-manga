namespace Manga.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using Manga.Application.Repositories;
    using Manga.Application.Outputs;

    public class GetAccountDetailsInteractor : IInputBoundary<GetAccountDetailsInput>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<AccountOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;

        public GetAccountDetailsInteractor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IOutputBoundary<AccountOutput> outputBoundary,
            IOutputConverter outputConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.outputConverter = outputConverter;
        }

        public async Task Process(GetAccountDetailsInput message)
        {
            var account = await accountReadOnlyRepository.Get(message.AccountId);
            if (account == null)
            {
                outputBoundary.Populate(null);
                return;
            }

            AccountOutput response = outputConverter.Map<AccountOutput>(account);
            outputBoundary.Populate(response);
        }
    }
}
