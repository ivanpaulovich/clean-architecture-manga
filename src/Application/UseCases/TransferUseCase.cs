// <copyright file="TransferUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.Transfer;
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Services;

    /// <summary>
    ///     Transfer
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class TransferUseCase : ITransferUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountService _accountService;
        private readonly ITransferOutputPort _transferOutputPort;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TransferUseCase" /> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="transferOutputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public TransferUseCase(
            AccountService accountService,
            ITransferOutputPort transferOutputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            this._accountService = accountService;
            this._transferOutputPort = transferOutputPort;
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(TransferInput input)
        {
            if (input is null)
            {
                this._transferOutputPort.WriteError(Messages.InputIsNull);
                return;
            }

            IAccount originAccount = await this._accountRepository
                .GetAccount(input.OriginAccountId)
                .ConfigureAwait(false);

            if (originAccount == null)
            {
                this._transferOutputPort
                    .NotFound(Messages.AccountDoesNotExist);
                return;
            }

            IAccount destinationAccount = await this._accountRepository
                .GetAccount(input.DestinationAccountId)
                .ConfigureAwait(false);

            if (destinationAccount == null)
            {
                this._transferOutputPort
                    .NotFound(Messages.AccountDoesNotExist);
                return;
            }

            IDebit debit = await this._accountService
                .Withdraw(originAccount, input.Amount)
                .ConfigureAwait(false);

            await this._accountService
                .Deposit(destinationAccount, input.Amount)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this.BuildOutput(debit, originAccount, destinationAccount);
        }

        private void BuildOutput(IDebit debit, IAccount originAccount, IAccount destinationAccount)
        {
            var output = new TransferOutput(
                debit,
                originAccount.GetCurrentBalance(),
                originAccount.Id,
                destinationAccount.Id);

            this._transferOutputPort
                .Standard(output);
        }
    }
}
