// <copyright file="Deposit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Credits;

    /// <summary>
    /// Deposit <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class Deposit : IUseCase
    {
        private readonly AccountService accountService;
        private readonly IOutputPort outputPort;
        private readonly IAccountRepository accountRepository;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deposit"/> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public Deposit(
            AccountService accountService,
            IOutputPort outputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            this.accountService = accountService;
            this.outputPort = outputPort;
            this.accountRepository = accountRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DepositInput input)
        {
            try
            {
                var account = await this.accountRepository.Get(input.AccountId);
                var credit = await this.accountService.Deposit(account, input.Amount);
                await this.unitOfWork.Save();

                this.BuildOutput(credit, account);
            }
            catch (AccountNotFoundException ex)
            {
                this.outputPort.NotFound(ex.Message);
                return;
            }
        }

        private void BuildOutput(ICredit credit, IAccount account)
        {
            var output = new DepositOutput(
                credit,
                account.GetCurrentBalance());

            this.outputPort.Standard(output);
        }
    }
}
