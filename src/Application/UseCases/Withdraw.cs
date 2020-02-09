// <copyright file="Withdraw.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Withdraw;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Withdraw <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class Withdraw : IUseCase
    {
        private readonly AccountService accountService;
        private readonly IOutputPort outputPort;
        private readonly IAccountRepository accountRepository;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Withdraw"/> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public Withdraw(
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
        public async Task Execute(WithdrawInput input)
        {
            try
            {
                var account = await this.accountRepository.GetAccount(input.AccountId)
                    .ConfigureAwait(false);
                var debit = await this.accountService.Withdraw(account, input.Amount)
                    .ConfigureAwait(false);

                await this.unitOfWork.Save()
                    .ConfigureAwait(false);

                this.BuildOutput(debit, account);
            }
            catch (AccountNotFoundException notFoundEx)
            {
                this.outputPort.NotFound(notFoundEx.Message);
                return;
            }
            catch (MoneyShouldBePositiveException outOfBalanceEx)
            {
                this.outputPort.OutOfBalance(outOfBalanceEx.Message);
                return;
            }
        }

        private void BuildOutput(IDebit debit, IAccount account)
        {
            var output = new WithdrawOutput(
                debit,
                account.GetCurrentBalance());

            this.outputPort.Standard(output);
        }
    }
}
