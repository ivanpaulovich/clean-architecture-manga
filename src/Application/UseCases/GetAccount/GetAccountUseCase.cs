// <copyright file="GetAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccount
{
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    /// <inheritdoc />
    public sealed class GetAccountUseCase : IGetAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountUseCase" /> class.
        /// </summary>
        /// <param name="accountRepository">Account Repository.</param>
        public GetAccountUseCase(IAccountRepository accountRepository) => this._accountRepository = accountRepository;

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(GetAccountInput input)
        {
            if (input.ModelState.IsValid)
            {
                return this.GetAccountInternal(input.AccountId);
            }

            this._outputPort?.Invalid(input.ModelState);
            return Task.CompletedTask;
        }

        private async Task GetAccountInternal(AccountId accountId)
        {
            IAccount account = await this._accountRepository
                .GetAccount(accountId)
                .ConfigureAwait(false);

            if (account is Account getAccount)
            {
                this._outputPort?.Ok(getAccount);
                return;
            }

            this._outputPort?.NotFound();
        }
    }
}
