// <copyright file="GetAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.GetAccount;
    using Domain.Accounts;

    /// <summary>
    ///     Get Account Details
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class GetAccountUseCase : IGetAccountUseCaseV2
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IGetAccountOutputPort _getAccountOutputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountUseCase" /> class.
        /// </summary>
        /// <param name="getAccountOutputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public GetAccountUseCase(
            IGetAccountOutputPort getAccountOutputPort,
            IAccountRepository accountRepository)
        {
            this._getAccountOutputPort = getAccountOutputPort;
            this._accountRepository = accountRepository;
        }

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAccountInput input)
        {
            if (input is null)
            {
                this._getAccountOutputPort.WriteError(Messages.InputIsNull);
                return;
            }

            IAccount account = await this._accountRepository
                .GetAccount(input.AccountId)
                .ConfigureAwait(false);

            if (account is null)
            {
                this._getAccountOutputPort
                    .NotFound(Messages.AccountDoesNotExist);
                return;
            }

            this.BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var output = new GetAccountOutput(account);
            this._getAccountOutputPort
                .Standard(output);
        }
    }
}
