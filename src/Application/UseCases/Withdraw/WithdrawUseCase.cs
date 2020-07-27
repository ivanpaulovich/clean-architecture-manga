// <copyright file="WithdrawUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.Withdraw
{
    using System;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class WithdrawUseCase : IWithdrawUseCase
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAccountRepository _accountRepository;
        private readonly ICurrencyExchange _currencyExchange;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WithdrawUseCase" /> class.
        /// </summary>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        /// <param name="accountFactory"></param>
        /// <param name="userService"></param>
        /// <param name="userRepository"></param>
        /// <param name="customerRepository"></param>
        /// <param name="currencyExchange"></param>
        public WithdrawUseCase(
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork,
            IAccountFactory accountFactory,
            IUserService userService,
            IUserRepository userRepository,
            ICustomerRepository customerRepository,
            ICurrencyExchange currencyExchange)
        {
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
            this._accountFactory = accountFactory;
            this._userService = userService;
            this._userRepository = userRepository;
            this._customerRepository = customerRepository;
            this._currencyExchange = currencyExchange;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(WithdrawInput input)
        {
            if (input.ModelState.IsValid)
            {
                return this.WithdrawInternal(input.AccountId, input.Amount);
            }

            this._outputPort?.Invalid(input.ModelState);
            return Task.CompletedTask;
        }

        private async Task WithdrawInternal(AccountId accountId, PositiveMoney withdrawAmount)
        {
            ExternalUserId externalUserId = this._userService
                .GetCurrentUser();

            IUser user = await this._userRepository
                .Find(externalUserId)
                .ConfigureAwait(false);

            if (user is UserNull)
            {
                this._outputPort?.NotFound();
                return;
            }

            ICustomer customer = await this._customerRepository
                .Find(user.UserId)
                .ConfigureAwait(false);

            if (customer is CustomerNull)
            {
                this._outputPort?.NotFound();
                return;
            }

            IAccount account = await this._accountRepository
                .Find(accountId, customer.CustomerId)
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
