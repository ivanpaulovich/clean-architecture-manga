// <copyright file="GetAccountsUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccounts
{
    using Domain;
    using Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetAccountsUseCase : IGetAccountsUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountsUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="accountRepository">Customer Repository.</param>
        public GetAccountsUseCase(
            IUserService userService,
            IAccountRepository accountRepository)
        {
            this._userService = userService;
            this._accountRepository = accountRepository;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public async Task Execute()
        {
            string externalUserId = this._userService
                .GetCurrentUserId();

            await this.GetAccountsInternal(externalUserId)
                .ConfigureAwait(false);
        }

        private async Task GetAccountsInternal(string externalUserId)
        {
            IList<Account>? accounts = await this._accountRepository
                .GetAccounts(externalUserId)
                .ConfigureAwait(false);

            this._outputPort?.Ok(accounts);
        }
    }
}
