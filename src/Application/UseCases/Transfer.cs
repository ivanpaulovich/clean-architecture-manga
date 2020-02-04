// <copyright file="Transfer.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Debits;

    /// <summary>
    /// Transfer <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class Transfer : IUseCase
    {
        private readonly AccountService accountService;
        private readonly IOutputPort outputPort;
        private readonly IAccountRepository accountRepository;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transfer"/> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public Transfer(
            AccountService accountService,
            IOutputPort outputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            this.accountService = accountService;
            this.outputPort = outputPort;
            this.accountRepository = accountRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(TransferInput input)
        {
            try
            {
                var originAccount = await this.accountRepository.Get(input.OriginAccountId);
                var destinationAccount = await this.accountRepository.Get(input.DestinationAccountId);

                var debit = await this.accountService.Withdraw(originAccount, input.Amount);
                var credit = await this.accountService.Deposit(destinationAccount, input.Amount);

                await this.unitOfWork.Save();

                this.BuildOutput(debit, originAccount, destinationAccount);
            }
            catch (AccountNotFoundException ex)
            {
                this.outputPort.NotFound(ex.Message);
                return;
            }
        }

        private void BuildOutput(IDebit debit, IAccount originAccount, IAccount destinationAccount)
        {
            var output = new TransferOutput(
                debit,
                originAccount.GetCurrentBalance(),
                originAccount.Id,
                destinationAccount.Id);

            this.outputPort.Standard(output);
        }
    }
}
