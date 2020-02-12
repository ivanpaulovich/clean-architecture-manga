// <copyright file="GetAccountDetails.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.GetAccountDetails;
    using Domain.Accounts;

    /// <summary>
    ///     Get Account Details
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class GetAccountDetailsUseCase : IUseCase, IUseCaseV2
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountDetailsUseCase" /> class.
        /// </summary>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public GetAccountDetailsUseCase(
            IOutputPort outputPort,
            IAccountRepository accountRepository)
        {
            this._outputPort = outputPort;
            this._accountRepository = accountRepository;
        }

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAccountDetailsInput input)
        {
            if (input is null)
            {
                this._outputPort.WriteError(Messages.InputIsNull);
                return;
            }

            IAccount account;

            try
            {
                account = await this._accountRepository.GetAccount(input.AccountId)
                    .ConfigureAwait(false);
            }
            catch (AccountNotFoundException ex)
            {
                this._outputPort.NotFound(ex.Message);
                return;
            }

            this.BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var output = new GetAccountDetailsOutput(account);
            this._outputPort.Standard(output);
        }
    }
}
