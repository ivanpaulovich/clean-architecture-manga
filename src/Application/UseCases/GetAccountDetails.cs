// <copyright file="GetAccountDetails.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccountDetails;
    using Domain.Accounts;

    /// <summary>
    /// Get Account Details <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class GetAccountDetails : IUseCase, IUseCaseV2
    {
        private readonly IOutputPort outputPort;
        private readonly IAccountRepository accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountDetails"/> class.
        /// </summary>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public GetAccountDetails(
            IOutputPort outputPort,
            IAccountRepository accountRepository)
        {
            this.outputPort = outputPort;
            this.accountRepository = accountRepository;
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
                account = await this.accountRepository.GetAccount(input.AccountId)
                    .ConfigureAwait(false);
            }
            catch (AccountNotFoundException ex)
            {
                this.outputPort.NotFound(ex.Message);
                return;
            }

            this.BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var output = new GetAccountDetailsOutput(account);
            this.outputPort.Standard(output);
        }
    }
}
