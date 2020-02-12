// <copyright file="CloseAccount.cs" company="Ivan Paulovich">
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
    public sealed class CloseAccountUseCase : IUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CloseAccountUseCase" /> class.
        /// </summary>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public CloseAccountUseCase(
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
        public async Task Execute(CloseAccountInput input)
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

            if (account.IsClosingAllowed())
            {
                await this._accountRepository.Delete(account)
                    .ConfigureAwait(false);
            }

            this.BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var closeAccountOutput = new CloseAccountOutput(account);
            this._outputPort.Standard(closeAccountOutput);
        }
    }
}
