// <copyright file="WithdrawUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.Withdraw;
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Services;

    /// <summary>
    ///     Withdraw
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class WithdrawUseCase : IWithdrawUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWithdrawOutputPort _withdrawOutputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WithdrawUseCase" /> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="withdrawOutputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public WithdrawUseCase(
            AccountService accountService,
            IWithdrawOutputPort withdrawOutputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            this._accountService = accountService;
            this._withdrawOutputPort = withdrawOutputPort;
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(WithdrawInput input)
        {
            if (input is null)
            {
                this._withdrawOutputPort
                    .WriteError(Messages.InputIsNull);
                return;
            }

            IAccount account = await this._accountRepository
                .GetAccount(input.AccountId)
                .ConfigureAwait(false);

            if (account is null)
            {
                this._withdrawOutputPort
                    .NotFound(Messages.AccountDoesNotExist);
                return;
            }

            try
            {
                IDebit debit = await this._accountService
                    .Withdraw(account, input.Amount)
                    .ConfigureAwait(false);

                await this._unitOfWork
                    .Save()
                    .ConfigureAwait(false);

                this.BuildOutput(debit, account);
            }
            catch (MoneyShouldBePositiveException outOfBalanceEx)
            {
                this._withdrawOutputPort
                    .OutOfBalance(outOfBalanceEx.Message);
            }
        }

        private void BuildOutput(IDebit debit, IAccount account)
        {
            var output = new WithdrawOutput(
                debit,
                account.GetCurrentBalance());

            this._withdrawOutputPort.Standard(output);
        }
    }
}
