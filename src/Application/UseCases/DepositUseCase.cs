// <copyright file="DepositUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.Deposit;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;
    using Services;

    /// <summary>
    ///     Deposit
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class DepositUseCase : IDepositUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountService _accountService;
        private readonly ICurrencyExchange _currencyExchange;
        private readonly IDepositOutputPort _depositOutputPort;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DepositUseCase" /> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="depositOutputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="currencyExchange">Currency Exchange Service.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public DepositUseCase(
            AccountService accountService,
            IDepositOutputPort depositOutputPort,
            IAccountRepository accountRepository,
            ICurrencyExchange currencyExchange,
            IUnitOfWork unitOfWork)
        {
            this._accountService = accountService;
            this._depositOutputPort = depositOutputPort;
            this._accountRepository = accountRepository;
            this._currencyExchange = currencyExchange;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DepositInput input)
        {
            if (input is null)
            {
                this._depositOutputPort
                    .WriteError(Messages.InputIsNull);
                return;
            }

            IAccount account = await this._accountRepository
                .GetAccount(input.AccountId)
                .ConfigureAwait(false);

            if (account is null)
            {
                this._depositOutputPort
                    .NotFound(Messages.AccountDoesNotExist);
                return;
            }

            PositiveMoney amountConverted = await this._currencyExchange
                .ConvertToUSD(input.Amount)
                .ConfigureAwait(false);

            ICredit credit = await this._accountService
                .Deposit(account, amountConverted)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this.BuildOutput(credit, account);
        }

        private void BuildOutput(ICredit credit, IAccount account)
        {
            var output = new DepositOutput(
                credit,
                account.GetCurrentBalance());

            this._depositOutputPort.Standard(output);
        }
    }
}
