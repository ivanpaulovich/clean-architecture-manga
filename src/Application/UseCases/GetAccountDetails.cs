namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccountDetails;
    using Domain.Accounts;

    /// <summary>
    /// Get Account Details Use Case.
    /// </summary>
    public sealed class GetAccountDetails : IUseCase, IUseCaseV2
    {
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountDetails"/> class.
        /// </summary>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public GetAccountDetails(
            IOutputPort outputPort,
            IAccountRepository accountRepository)
        {
            _outputPort = outputPort;
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAccountDetailsInput input)
        {
            IAccount account;

            try
            {
                account = await _accountRepository.Get(input.AccountId);
            }
            catch (AccountNotFoundException ex)
            {
                _outputPort.NotFound(ex.Message);
                return;
            }

            BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var output = new GetAccountDetailsOutput(account);
            _outputPort.Standard(output);
        }
    }
}
