// <copyright file="GetCustomerUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetCustomer
{
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class GetCustomerUseCase : IGetCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetCustomerUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="customerRepository">Customer Repository.</param>
        /// <param name="userRepository"></param>
        public GetCustomerUseCase(
            IUserService userService,
            ICustomerRepository customerRepository,
            IUserRepository userRepository)
        {
            this._userService = userService;
            this._customerRepository = customerRepository;
            this._userRepository = userRepository;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute()
        {
            ExternalUserId externalUserId = this._userService
                .GetCurrentUser();

            return this.GetCustomerInternal(externalUserId);
        }

        private async Task GetCustomerInternal(ExternalUserId externalUserId)
        {
            IUser user = await this._userRepository
                .Find(externalUserId)
                .ConfigureAwait(false);

            ICustomer customer = await this._customerRepository
                .Find(user.UserId)
                .ConfigureAwait(false);

            if (customer is Customer getCustomer)
            {
                this._outputPort?.Ok(getCustomer);
                return;
            }

            this._outputPort?.NotFound();
        }
    }
}
