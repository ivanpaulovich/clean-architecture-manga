// <copyright file="GetAccountsUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Boundaries.GetAccounts;
    using Domain.Accounts;
    using Domain.Security;
    using Domain.Security.Services;

    /// <summary>
    ///     Get Customer Details
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class GetAccountsUseCase : IGetAccountsUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IGetAccountsOutputPort _getAccountsOutputPort;
        private readonly IUserService _userService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetCustomerUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="getAccountsOutputPort">Output Port.</param>
        /// <param name="accountRepository">Customer Repository.</param>
        public GetAccountsUseCase(
            IUserService userService,
            IGetAccountsOutputPort getAccountsOutputPort,
            IAccountRepository accountRepository)
        {
            this._userService = userService;
            this._getAccountsOutputPort = getAccountsOutputPort;
            this._accountRepository = accountRepository;
        }

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAccountsInput input)
        {
            if (input is null)
            {
                this._getAccountsOutputPort
                    .WriteError(Messages.InputIsNull);
                return;
            }

            IUser user = this._userService
                .GetUser();

            List<IAccount> accounts = new List<IAccount>();

            if (user.CustomerId is { } customerId)
            {
                accounts.AddRange(await this._accountRepository
                    .GetBy(customerId)
                    .ConfigureAwait(false));
            }

            var output = new GetAccountsOutput(accounts);
            this._getAccountsOutputPort
                .Standard(output);
        }
    }
}
