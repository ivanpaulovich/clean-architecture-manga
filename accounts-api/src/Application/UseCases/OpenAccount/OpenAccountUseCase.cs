// <copyright file="OpenAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OpenAccount
{
    using Domain;
    using Domain.Credits;
    using Domain.ValueObjects;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class OpenAccountUseCase : IOpenAccountUseCase
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        public OpenAccountUseCase(
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork,
            IUserService userService,
            IAccountFactory accountFactory)
        {
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._accountFactory = accountFactory;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(decimal amount, string currency)
        {
            var input = new OpenAccountInput(amount, currency);

            if (input.ModelState.IsValid)
            {
                return this.OpenAccountInternal(input.Amount);
            }

            this._outputPort?.Invalid(input.ModelState);
            return Task.CompletedTask;
        }

        private async Task OpenAccountInternal(PositiveMoney amountToDeposit)
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            Account account = this._accountFactory
                .NewAccount(externalUserId, amountToDeposit.Currency);

            Credit credit = this._accountFactory
                .NewCredit(account, amountToDeposit, DateTime.Now);

            await this.Deposit(account, credit)
                .ConfigureAwait(false);

            this._outputPort?.Ok(account);
        }

        private async Task Deposit(Account account, Credit credit)
        {
            account.Deposit(credit);

            await this._accountRepository
                .Add(account, credit)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
