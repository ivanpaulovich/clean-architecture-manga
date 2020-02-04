// <copyright file="CloseAccount.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.CloseAccount;
    using Domain.Accounts;

    /// <summary>
    /// Close Account <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class CloseAccount : IUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly IAccountRepository accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloseAccount"/> class.
        /// </summary>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public CloseAccount(
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
        public async Task Execute(CloseAccountInput input)
        {
            IAccount account;

            try
            {
                account = await this.accountRepository.Get(input.AccountId);
            }
            catch (AccountNotFoundException ex)
            {
                this.outputPort.NotFound(ex.Message);
                return;
            }

            if (account.IsClosingAllowed())
            {
                await this.accountRepository.Delete(account);
            }

            this.BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var closeAccountOutput = new CloseAccountOutput(account);
            this.outputPort.Standard(closeAccountOutput);
        }
    }
}
