// <copyright file="Withdraw.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Application.Boundaries.Withdraw;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Withdraw <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class WithdrawUseCase : IUseCase
    {
        private readonly AccountService _accountService;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawUseCase"/> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public WithdrawUseCase(
            AccountService accountService,
            IOutputPort outputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            this._accountService = accountService;
            this._outputPort = outputPort;
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(WithdrawInput input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            try
            {
                var account = await this._accountRepository.GetAccount(input.AccountId)
                    .ConfigureAwait(false);
                var debit = await this._accountService.Withdraw(account, input.Amount)
                    .ConfigureAwait(false);

                await this._unitOfWork.Save()
                    .ConfigureAwait(false);

                this.BuildOutput(debit, account);
            }
            catch (AccountNotFoundException notFoundEx)
            {
                this._outputPort.NotFound(notFoundEx.Message);
                return;
            }
            catch (MoneyShouldBePositiveException outOfBalanceEx)
            {
                this._outputPort.OutOfBalance(outOfBalanceEx.Message);
                return;
            }
        }

        private void BuildOutput(IDebit debit, IAccount account)
        {
            var output = new WithdrawOutput(
                debit,
                account.GetCurrentBalance());

            this._outputPort.Standard(output);
        }
    }
}
