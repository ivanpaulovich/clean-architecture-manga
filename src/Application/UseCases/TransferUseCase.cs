// <copyright file="Transfer.cs" company="Ivan Paulovich">
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
    public sealed class TransferTransferUseCase : ITransferUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountService _accountService;
        private readonly ITransferOutputPort _transferOutputPort;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TransferTransferUseCase" /> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="transferOutputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public TransferTransferUseCase(
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

            try
            {
                var originAccount = await this._accountRepository
                    .GetAccount(input.OriginAccountId)
                    .ConfigureAwait(false);
                var destinationAccount = await this._accountRepository
                    .GetAccount(input.DestinationAccountId)
                    .ConfigureAwait(false);

                var debit = await this._accountService.Withdraw(originAccount, input.Amount)
                    .ConfigureAwait(false);
                var credit = await this._accountService.Deposit(destinationAccount, input.Amount)
                    .ConfigureAwait(false);

                await this._unitOfWork.Save()
                    .ConfigureAwait(false);

                this.BuildOutput(debit, originAccount, destinationAccount);
            }
            catch (AccountNotFoundException ex)
            {
                this._transferOutputPort.NotFound(ex.Message);
            }
        }

        private void BuildOutput(IDebit debit, IAccount originAccount, IAccount destinationAccount)
        {
            var output = new TransferOutput(
                debit,
                originAccount.GetCurrentBalance(),
                originAccount.Id,
                destinationAccount.Id);

            this._transferOutputPort.Standard(output);
        }
    }
}
