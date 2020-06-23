// <copyright file="CloseAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.CloseAccount;
    using Domain.Accounts;

    /// <summary>
    ///     Close Account
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class CloseAccountUseCase : ICloseAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICloseAccountOutputPort _closeAccountGetAccountsOutputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CloseAccountUseCase" /> class.
        /// </summary>
        /// <param name="closeAccountGetAccountsOutputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public CloseAccountUseCase(
            ICloseAccountOutputPort closeAccountGetAccountsOutputPort,
            IAccountRepository accountRepository)
        {
            this._closeAccountGetAccountsOutputPort = closeAccountGetAccountsOutputPort;
            this._accountRepository = accountRepository;
        }

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(CloseAccountInput input)
        {
            if (input is null)
            {
                this._closeAccountGetAccountsOutputPort
                    .WriteError(Messages.InputIsNull);
                return;
            }

            IAccount account = await this._accountRepository
                .GetAccount(input.AccountId)
                .ConfigureAwait(false);

            if (account is null)
            {
                this._closeAccountGetAccountsOutputPort
                    .NotFound(Messages.AccountDoesNotExist);
                return;
            }

            if (account.IsClosingAllowed())
            {
                await this._accountRepository
                    .Delete(account)
                    .ConfigureAwait(false);
            }

            this.BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var closeAccountOutput = new CloseAccountOutput(account);
            this._closeAccountGetAccountsOutputPort
                .Standard(closeAccountOutput);
        }
    }
}
