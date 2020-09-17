// <copyright file="WithdrawUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Withdraw
{
    using Domain;
    using Domain.Debits;
    using Domain.ValueObjects;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class WithdrawUseCase : IWithdrawUseCase
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAccountRepository _accountRepository;
        private readonly ICurrencyExchange _currencyExchange;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WithdrawUseCase" /> class.
        /// </summary>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        /// <param name="accountFactory"></param>
        /// <param name="userService"></param>
        /// <param name="currencyExchange"></param>
        public WithdrawUseCase(
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork,
            IAccountFactory accountFactory,
            IUserService userService,
            ICurrencyExchange currencyExchange)
        {
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
            this._accountFactory = accountFactory;
            this._userService = userService;
            this._currencyExchange = currencyExchange;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid accountId, decimal amount, string currency)
        {
            var input = new WithdrawInput(accountId, amount, currency);

            if (input.ModelState.IsValid)
            {
                return this.WithdrawInternal(input.AccountId, input.Amount);
            }

            this._outputPort?.Invalid(input.ModelState);
            return Task.CompletedTask;
        }

        private async Task WithdrawInternal(AccountId accountId, PositiveMoney withdrawAmount)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            IAccount account = await this._accountRepository
                .Find(accountId, externalUserId)
                .ConfigureAwait(false);

            if (account is Account withdrawAccount)
            {
                PositiveMoney localCurrencyAmount =
                    await this._currencyExchange
                        .Convert(withdrawAmount, withdrawAccount.Currency)
                        .ConfigureAwait(false);

                Debit debit = this._accountFactory
                    .NewDebit(withdrawAccount, localCurrencyAmount, DateTime.Now);

                if (withdrawAccount.GetCurrentBalance().Amount - debit.Amount.Amount < 0)
                {
                    this._outputPort?.OutOfFunds();
                    return;
                }

                await this.Withdraw(withdrawAccount, debit)
                    .ConfigureAwait(false);

                this._outputPort?.Ok(debit, withdrawAccount);
                return;
            }

            this._outputPort?.NotFound();
        }

        private async Task Withdraw(Account account, Debit debit)
        {
            account.Withdraw(debit);

            await this._accountRepository
                .Update(account, debit)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
