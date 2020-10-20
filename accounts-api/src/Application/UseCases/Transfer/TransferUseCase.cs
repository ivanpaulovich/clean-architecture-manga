// <copyright file="TransferUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Transfer
{
    using System;
    using System.Threading.Tasks;
    using Domain;
    using Domain.Credits;
    using Domain.Debits;
    using Domain.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class TransferUseCase : ITransferUseCase
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAccountRepository _accountRepository;
        private readonly ICurrencyExchange _currencyExchange;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TransferUseCase" /> class.
        /// </summary>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        /// <param name="accountFactory"></param>
        /// <param name="currencyExchange"></param>
        public TransferUseCase(
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork,
            IAccountFactory accountFactory,
            ICurrencyExchange currencyExchange)
        {
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
            this._accountFactory = accountFactory;
            this._currencyExchange = currencyExchange;
            this._outputPort = new TransferPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid originAccountId, Guid destinationAccountId, decimal amount, string currency) =>
            this.Transfer(
                new AccountId(originAccountId),
                new AccountId(destinationAccountId),
                new Money(amount, new Currency(currency)));

        private async Task Transfer(AccountId originAccountId, AccountId destinationAccountId,
            Money transferAmount)
        {
            IAccount originAccount = await this._accountRepository
                .GetAccount(originAccountId)
                .ConfigureAwait(false);

            IAccount destinationAccount = await this._accountRepository
                .GetAccount(destinationAccountId)
                .ConfigureAwait(false);

            if (originAccount is Account withdrawAccount && destinationAccount is Account depositAccount)
            {
                Money localCurrencyAmount =
                    await this._currencyExchange
                        .Convert(transferAmount, withdrawAccount.Currency)
                        .ConfigureAwait(false);

                Debit debit = this._accountFactory
                    .NewDebit(withdrawAccount, localCurrencyAmount, DateTime.Now);

                if (withdrawAccount.GetCurrentBalance().Subtract(debit.Amount).Amount < 0)
                {
                    this._outputPort?.OutOfFunds();
                    return;
                }

                await this.Withdraw(withdrawAccount, debit)
                    .ConfigureAwait(false);

                Money destinationCurrencyAmount =
                    await this._currencyExchange
                        .Convert(transferAmount, depositAccount.Currency)
                        .ConfigureAwait(false);

                Credit credit = this._accountFactory
                    .NewCredit(depositAccount, destinationCurrencyAmount, DateTime.Now);

                await this.Deposit(depositAccount, credit)
                    .ConfigureAwait(false);

                this._outputPort?.Ok(withdrawAccount, debit, depositAccount, credit);
                return;
            }

            this._outputPort?.NotFound();
        }

        private async Task Deposit(Account account, Credit credit)
        {
            account.Deposit(credit);

            await this._accountRepository
                .Update(account, credit)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
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
