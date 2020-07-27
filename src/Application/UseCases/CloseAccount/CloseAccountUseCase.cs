// <copyright file="CloseAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class CloseAccountUseCase : ICloseAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CloseAccountUseCase" /> class.
        /// </summary>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="customerRepository">Customer Repository.</param>
        /// <param name="userService">User Service.</param>
        /// <param name="unitOfWork"></param>
        /// <param name="userRepository"></param>
        public CloseAccountUseCase(
            IAccountRepository accountRepository,
            ICustomerRepository customerRepository,
            IUserService userService,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            this._accountRepository = accountRepository;
            this._customerRepository = customerRepository;
            this._userService = userService;
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(CloseAccountInput input)
        {
            if (input.ModelState.IsValid)
            {
                return this.CloseAccountInternal(input.AccountId);
            }

            this._outputPort?.Invalid(input.ModelState);

            return Task.CompletedTask;
        }

        private async Task CloseAccountInternal(AccountId accountId)
        {
            ExternalUserId externalUserId = this._userService
                .GetCurrentUser();

            IUser existingUser = await this._userRepository
                .Find(externalUserId)
                .ConfigureAwait(false);

            ICustomer customer = await this._customerRepository
                .Find(existingUser.UserId)
                .ConfigureAwait(false);

            if (customer is CustomerNull)
            {
                this._outputPort?.NotFound();
                return;
            }

            IAccount account = await this._accountRepository
                .Find(accountId, customer.CustomerId)
                .ConfigureAwait(false);

            if (account is Account closingAccount)
            {
                if (!closingAccount.IsClosingAllowed())
                {
                    this._outputPort?.HasFunds();
                    return;
                }

                await this.Close(closingAccount)
                    .ConfigureAwait(false);

                this._outputPort?.Ok(closingAccount);
                return;
            }

            this._outputPort?.NotFound();
        }

        private async Task Close(Account closeAccount)
        {
            await this._accountRepository
                .Delete(closeAccount.AccountId)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
