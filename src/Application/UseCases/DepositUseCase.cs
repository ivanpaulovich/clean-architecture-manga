// <copyright file="DepositUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.Deposit;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
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
        private readonly IDepositOutputPort _depositGetAccountsOutputPort;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DepositUseCase" /> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="depositGetAccountsOutputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public DepositUseCase(
            AccountService accountService,
            IDepositOutputPort depositGetAccountsOutputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            this._accountService = accountService;
            this._depositGetAccountsOutputPort = depositGetAccountsOutputPort;
            this._accountRepository = accountRepository;
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
                this._depositGetAccountsOutputPort
                    .WriteError(Messages.InputIsNull);
                return;
            }

            IAccount account = await this._accountRepository
                .GetAccount(input.AccountId)
                .ConfigureAwait(false);

            if (account is null)
            {
                this._depositGetAccountsOutputPort
                    .NotFound(Messages.AccountDoesNotExist);
                return;
            }

            ICredit credit = await this._accountService
                .Deposit(account, input.Amount)
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

            this._depositGetAccountsOutputPort.Standard(output);
        }
    }
}
